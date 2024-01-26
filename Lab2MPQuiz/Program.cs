

using Lab2MPQuiz;
using Lab2MPQuiz.Models;
using Lab2MPQuiz.Data;
using Newtonsoft.Json;


namespace Lab2MPQuiz
{
    using MongoDB;
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            MongoCRUD db = new MongoCRUD("quizdb");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
           // if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

          // app.UseAuthorization();

            app.MapGet("/quizs", async () =>
            {

                List<Quiz> quiz = new List<Quiz>();
                quiz = await db.GetAllQuiz("quiz");
                return Results.Ok(quiz.ToList());
                
            });


            app.MapPost("/quiz", async (Quiz quiz) =>
            {
                Quiz quizToAdd = await db.AddQuiz("quiz", quiz);
                return Results.Ok(quizToAdd);
            });

            app.MapPut("/quiz", async (Quiz quiz) =>
            {
                Quiz QuizToUpdate =await db.UpdateQuiz("quiz", quiz);
            });

            app.MapDelete("/quiz/{id}", async (Guid id) =>
            {
                await db.DeteteQuiz("quiz", id);
            });

            app.Run();
        }
    }
}