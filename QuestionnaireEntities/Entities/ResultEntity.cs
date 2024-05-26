using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuestionnaireEntities.Entities;

[Table("results")]
public class ResultEntity : BaseEntity
{
    /// <summary>
    ///     Ключ для получения ответа
    /// </summary>
    [Column("answer_id")]
    [ForeignKey(nameof(Answer))]
    public long AnswerId { get; set; }
    
    /// <summary>
    ///     Id интервью
    /// </summary>
    [Column("interview_id")]
    [ForeignKey(nameof(Interview))]
    public long InterviewId { get; set; }

    /// <summary>
    ///     Навигационное свойство на вопрос
    /// </summary>
    public AnswerEntity Answer { get; set; }
    
    /// <summary>
    ///     Навигационное свойство на интервью
    /// </summary>
    public InterviewEntity Interview { get; set; }

    /// <summary>
    ///     Применить модель
    /// </summary>
    public static void SetUp(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ResultEntity>()
            .HasIndex(e => e.InterviewId)
            .HasName("IX_results_interview_id")
            .HasMethod("hash");
        
        modelBuilder.Entity<ResultEntity>()
            .HasIndex(e => e.AnswerId)
            .HasName("IX_results_answer_id")
            .HasMethod("hash");
    }
}