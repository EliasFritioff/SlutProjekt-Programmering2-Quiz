using System;
using System.Collections.Generic;

namespace QuizGame.Models
{
    public class Quiz
    {
        public List<Question> Questions { get; set; }
        public Player Player { get; set; }

        public Quiz(Player player, List<Question> questions)
        {
            Player = player;
            Questions = questions;
        }

        public void Start()
        {
            foreach (var question in Questions)
            {
                Console.WriteLine($"\n{question.Text}");
                for (int i = 0; i < question.Options.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.Options[i]}");
                }

                Console.Write("Ditt svar (nummer): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice) &&
                    choice >= 1 && choice <= question.Options.Length)
                {
                    if (question.IsCorrect(question.Options[choice - 1]))
                    {
                        Console.WriteLine("Rätt!");
                        Player.AddPoint();
                    }
                    else
                    {
                        Console.WriteLine($"Fel. Rätt svar: {question.CorrectAnswer}");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt svar.");
                }
            }

            Console.WriteLine($"\n{Player.Name}, du fick {Player.Score} poäng.");
        }
    }
}
