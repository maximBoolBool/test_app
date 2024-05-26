using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionnaireEntities.Entities;

/// <summary>
///     Базовая сущность
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    ///     Id
    /// </summary>
    [Column("id")]
    public long Id { get; set; }
}