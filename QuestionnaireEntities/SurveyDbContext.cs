using Microsoft.EntityFrameworkCore;
using QuestionnaireEntities.Entities;

namespace QuestionnaireEntities;

public class SurveyDbContext : DbContext
{
    #region Tables

    public DbSet<SurveyEntity> Surveies { get; set; } = null!;

    public DbSet<ResultEntity> Results { get; set; } = null!;

    public DbSet<QuestionEntity> Questions { get; set; } = null!;

    public DbSet<InterviewEntity> Interviews { get; set; } = null!;

    public DbSet<AnswerEntity> Answers { get; set; } = null!;

    #endregion

    #region .ctor
    
    public SurveyDbContext() : base() { }
    
    public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options) { }
    
    #endregion

    #region Ovverides

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        AnswerEntity.SetUp(modelBuilder);
        InterviewEntity.SetUp(modelBuilder);
        QuestionEntity.SetUp(modelBuilder);
        ResultEntity.SetUp(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#if DEBUG
        optionsBuilder.UseNpgsql("");
        base.OnConfiguring(optionsBuilder);  
#endif
    }

    #endregion
}