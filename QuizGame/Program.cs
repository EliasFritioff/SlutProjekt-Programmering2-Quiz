using QuizGame.Models;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Välkommen till quizet!");

        // Ladda frågor från JSON
        var questions = QuestionLoader.LoadFromFile("Data/questions.json");

        // Skapa spelare
        Console.Write("Ange ditt namn: ");
        var name = Console.ReadLine();
        var player = new Player(name);

        // Starta quiz
        var quiz = new Quiz(questions);
        var score = quiz.Start();

        // Visa resultat
        Console.WriteLine($"{player.Name}, du fick {score} poäng av {questions.Count} möjliga!");
    }
}
