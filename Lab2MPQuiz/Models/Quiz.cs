using MongoDB.Bson.Serialization.Attributes;

namespace Lab2MPQuiz.Models
{
    public class Quiz
    {
        [BsonId]
        public Guid Id { get; set; }
        public List<Questions> _questions { get; set; }
      
        //public Questions[] _questions;
        public string _title { get; set; } = string.Empty;
        public string Title => _title;

        public Quiz()
        {
         _questions = new List<Questions>();
        
        }

    }
}


