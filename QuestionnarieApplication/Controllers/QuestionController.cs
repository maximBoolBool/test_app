using Microsoft.AspNetCore.Mvc;
using QuestionnaireServices.Models.Requests;
using QuestionnaireServices.Services;

namespace QuestionnarieApplication.Controllers;

[Route("api/questions")]
public class QuestionController : Controller
{
    #region Fieldes

    private readonly IQuestionnaireService _service;

    #endregion

    #region .ctor
    
    public QuestionController(IQuestionnaireService service)
    {
        _service = service;
    }

    #endregion
    
    #region GET api/questions{id}

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetQuestion([FromQuery] long id, CancellationToken cancellationToken)
    {
        var response = await _service.GetQuestionByIdAsync(id, cancellationToken);
        return Ok(response);
    }

    #endregion

    #region POST api/questions/save

    [HttpPost("save")]
    public async Task<IActionResult> SaveResult(
        [FromBody] UpplyResultRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _service.SaveQuestionResult(request, cancellationToken);
        return Ok(response);
    }

    #endregion
}