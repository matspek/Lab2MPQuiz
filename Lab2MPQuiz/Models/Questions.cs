namespace Lab2MPQuiz.Models
{
    public class Questions
    {
        public string question { get; set; }
        public string[] answer = new string[4];
        public int correctanswer { get; set; }
    }
}
