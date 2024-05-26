using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionnaireEntities.Entities;

[Table("surveys")]
public class SurveyEntity : BaseEntity
{
    /// <summary>
    ///     Название опроса
    /// </summary>
    [Column("name")]
    public string Name { get; set; }
    
    /// <summary>
    ///     Время создания опроса
    /// </summary>
    [Column("created")]
    public DateTime Created { get; set; }
    
    /// <summary>
    ///     Навигационное свойство для вопросов в анкете
    /// </summary>
    public ICollection<QuestionEntity> Questions { get; set; }
}