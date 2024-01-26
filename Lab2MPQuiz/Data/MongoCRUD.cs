using Lab2MPQuiz.Models;
using MongoDB.Driver;

namespace Lab2MPQuiz.Data
{
    public class MongoCRUD
    {
            private IMongoDatabase db;

            public MongoCRUD(string Database)
            {
                var client = new MongoClient("");
                db = client.GetDatabase(Database);
            }
            public async Task<Quiz> AddQuiz(string table, Quiz quiz)
            {
                var collection = db.GetCollection<Quiz>(table);
                await collection.InsertOneAsync(quiz);
                return quiz;
            }
            public async Task<List<Quiz>> GetAllQuiz(string table)
            {
                var collection =  db.GetCollection<Quiz>(table);
                return await collection.Find(_ => true).ToListAsync();
            }

            public async Task<Quiz> UpdateQuiz(string table, Quiz quiz)
            {
                var collection = db.GetCollection<Quiz>(table);
                quiz._title = "potatis";
                await collection.ReplaceOneAsync(x => x.Id == quiz.Id, quiz, new ReplaceOptions { IsUpsert = true });
                return quiz;
            }
            public async Task DeteteQuiz(string table, Guid id)
            {
                var collection = db.GetCollection<Quiz>(table);
                await collection.DeleteOneAsync(x => x.Id == id);
            }
            public void ClearDatabase(string table)
            {
                var collection = db.GetCollection<Quiz>(table);
                collection.DeleteMany(_ => true);
            }
        }
    

}
