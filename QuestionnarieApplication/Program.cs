using System.Reflection;
using FluentValidation.AspNetCore;
using QuestionnaireEntities;
using QuestionnaireServices;
using QuestionnarieApplication.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddQuestionnarieEntities(builder.Configuration);
builder.Services.AddQuestionnaireServices();
builder.Services.AddControllers()
    .AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

app.Services.ApplyMigration<SurveyDbContext>();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();
app.Run();
