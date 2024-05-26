using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuestionnaireEntities.Entities;

/// <summary>
///     Сущность вопроса в анкете
/// </summary>
[Table("questions")]
public class QuestionEntity : BaseEntity
{
    [Column("question")]
    public string Question { get; set; }

    /// <summary>
    ///     Порядок располложения вопроса в анкете
    /// </summary>
    [Column("place_in_survey")]
    public int PlaceInSurvey { get; set; } 
    
    /// <summary>
    ///     Id опроса    
    /// </summary>
    [ForeignKey(nameof(Survey))]
    [Column("survey_id")]
    public long SurveyId { get; set; }
    
    /// <summary>
    ///     Обязательный вопрос
    /// </summary>
    [Column("is_required")]
    public bool IsRequired { get; set; }
    
    /// <summary>
    ///     True если предусмотренно несколько
    ///     вариантов ответов
    /// </summary>
    [Column("is_multi_choice")]
    public bool IsMultiChoice { get; set; }
    
    /// <summary>
    ///     Навигационное свойство для анкеты
    /// </summary>
    public SurveyEntity Survey { get; set; }
    
    /// <summary>
    ///     Навигационное свойство для ответов
    /// </summary>
    public ICollection<AnswerEntity> Answers { get; set; }

    /// <summary>
    ///     Применить модель
    /// </summary>
    public static void SetUp(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuestionEntity>()
            .HasIndex(e => e.SurveyId)
            .HasDatabaseName("IX_questions_survey_id")
            .HasMethod("hash");
    }
}