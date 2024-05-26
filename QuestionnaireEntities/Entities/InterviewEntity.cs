using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuestionnaireEntities.Entities;

[Table("interviews")]
public class InterviewEntity : BaseEntity
{
    /// <summary>
    ///     Id опроса
    /// </summary>
    [Column("survey_id")]
    [ForeignKey(nameof(Survey))]
    public long SurveyId { get; set; }

    /// <summary>
    ///     Время прохождения анкеты
    /// </summary>
    [Column("from")]
    public DateTime From { get; set; }
    
    /// <summary>
    ///     Навигационное свойство для анкеты
    /// </summary>
    public SurveyEntity Survey { get; set; }

    /// <summary>
    ///     Навишационное свойство для результатов анкеты
    /// </summary>
    public List<ResultEntity> Results { get; set; } = new();

    /// <summary>
    ///     Применить модель
    /// </summary>
    public static void SetUp(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InterviewEntity>()
            .HasIndex(e => e.SurveyId)
            .HasDatabaseName("IX_interviews_survey_id")
            .HasMethod("hash");
    }
    
}