using System;
using QuizGame.Models;

namespace QuizGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Skriv ditt namn: ");
            string name = Console.ReadLine();

            var player = new Player(name);
            var questions = QuestionLoader.LoadFromFile("C:\Users\elias.fritioff\QuizGame\data\questions.json");
            var quiz = new Quiz(player, questions);
            quiz.Start();
        }
    }
}
