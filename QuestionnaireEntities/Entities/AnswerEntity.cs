using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuestionnaireEntities.Entities;

/// <summary>
///     Сущность вариантов ответов
/// </summary>
[Table("answers")]
public class AnswerEntity : BaseEntity
{
    /// <summary>
    ///     Ответ на вопрос
    /// </summary>
    [Column("response")]
    public string Response { get; set; }
    
    /// <summary>
    ///     
    /// </summary>
    [ForeignKey(nameof(Question))]
    [Column("question_id")]
    public long QuestionId { get; set; }
    
    /// <summary>
    ///     Навигационное свойство на вопрос
    /// </summary>
    public QuestionEntity Question { get; set; }

    /// <summary>
    ///     Применить модель
    /// </summary>
    public static void SetUp(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnswerEntity>()
            .HasIndex(e => e.QuestionId)
            .HasDatabaseName("IX_answer_question_id")
            .HasMethod("hash");
    }
}