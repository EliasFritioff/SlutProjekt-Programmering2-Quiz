using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace QuizGame.Models
{
    public class QuestionLoader
    {
        public static List<Question> LoadFromFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Question>>(json);
        }
    }
}
