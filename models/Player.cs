namespace QuizGame.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Player(string name)
        {
            Name = name;
            Score = 0;
        }

        public void AddPoint()
        {
            Score++;
        }
    }
}
