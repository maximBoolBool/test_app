using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuestionnaireEntities;
using QuestionnaireEntities.Entities;
using QuestionnaireServices.ErrorModels;
using QuestionnaireServices.Models;
using QuestionnaireServices.Models.Requests;

namespace QuestionnaireServices.Services.Impl;

/// <inheritdoc/>
public class QuestionnaireService : IQuestionnaireService
{
    #region Fieldes
    
    private readonly IMapper _mapper;
    private readonly ISurveyDbWorker _dbWorker;

    #endregion

    #region .ctor

    public QuestionnaireService(ISurveyDbWorker dbWorker, IMapper mapper)
    {
        _dbWorker = dbWorker;
        _mapper = mapper;
    }

    #endregion
    
    #region Public Methodes

    /// <inheritdoc />
    public async Task<QuestionResponse> GetQuestionByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var question = await _dbWorker.Questions
            .CreateQuery()
            .Include(e => e.Answers)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        if (question == null)
        {
            throw new ErrorException(HttpStatusCode.NotFound, $"Question with id {id} does not exist");
        }

        return _mapper.Map<QuestionResponse>(question);
    }

    /// <inheritdoc />
    public async Task<NextQuestionResult> SaveQuestionResult(
        UpplyResultRequest request,
        CancellationToken cancellationToken = default)
    {
        var question = await _dbWorker.Questions.GetByIdAsync(request.QuestionId, cancellationToken);
        if (question == null)
        {
            throw new ErrorException(HttpStatusCode.NotFound, $"Does not exist question with id {request.QuestionId}");
        }

        await ApplyChanges(request, cancellationToken);

        var questions = await _dbWorker.Questions
            .ListAsync(e => e.SurveyId == request.SurveyId, cancellationToken);

        var nextQuestion = questions.MinBy(e => e.PlaceInSurvey > request.QuestionId);

        return new()
        {
            QuestionCount = questions.Count,
            QuestionId = nextQuestion?.Id,
            QuestionNumber = nextQuestion?.PlaceInSurvey ?? questions.Count,
            IsEnd = nextQuestion == null
        };
    }

    #endregion

    #region Private Methodes

    private async Task ApplyChanges(
        UpplyResultRequest request,
        CancellationToken cancellationToken)
    {
        List<ResultEntity> newResults;
        InterviewEntity? interview;
        
        if (request.InterviewId == null)
        {
            interview = new()
            {
                From = DateTime.UtcNow,
                SurveyId = request.SurveyId,
            };
            
            newResults = request.AnswerIds.Select(id => new ResultEntity
            {
                AnswerId = id,
            }).ToList();

            interview.Results = newResults;
            _dbWorker.Inteviews.Add(interview);
            await _dbWorker.SaveChangesAsync(cancellationToken);
            return;
        }

        interview = await _dbWorker.Inteviews
            .GetByIdAsync(request.InterviewId.Value, cancellationToken);

        if (interview == null)
        {
            throw new ErrorException(HttpStatusCode.NotFound, $"Does not exist interview with id {request.InterviewId}");
        }
        
        newResults = request.AnswerIds.Select(id => new ResultEntity
        {
            AnswerId = id,
            InterviewId = interview.Id
        }).ToList();
        await _dbWorker.Results.AddRange(newResults);
        await _dbWorker.SaveChangesAsync(cancellationToken);
    }

    #endregion
}