using GameNamespace;
using System.Collections.Generic;

namespace GameAccountNamesspace
{
    public abstract class GameAccount
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        protected int Rating = 10;
        protected List<BaseGame> gameHistory = new List<BaseGame>();

        public int CurrentRating
        {
            get => Rating;
            set => Rating = value > 0 ? value : 1;
        }

        public GameAccount(int id, string userName)
        {
             Id = id;
            UserName = userName;
           
        }

        public abstract void WinGame(BaseGame game);
        public abstract void LoseGame(BaseGame game);

        public void GetStats()
        {
            Console.WriteLine($"Stats for {UserName}:");
            foreach (var game in gameHistory)
            {
                Console.WriteLine($"| Game ID: {game.GameId} | Opponent: {game.OpponentName} | Result: {game.Result} | Rating: {game.Rating} |");
            }
        }
    }
}
