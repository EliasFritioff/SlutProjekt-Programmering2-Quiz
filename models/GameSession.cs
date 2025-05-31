using System.Collections.Generic;

namespace QuizGame.Models
{
    public class GameSession
    {
        public List<Player> Players { get; set; }

        public GameSession()
        {
            Players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        // Här kan du lägga till multiplayer-logik
    }
}
