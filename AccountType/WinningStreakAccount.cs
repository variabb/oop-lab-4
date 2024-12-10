using GameNamespace;
using System.Collections.Generic;

namespace GameAccountNamesspace
{
    public class WinningStreakAccount : GameAccount
    {
        private int winningStreak = 0;

      public WinningStreakAccount(int id, string userName) : base(id, userName) 
        {
        }

        public override void WinGame(BaseGame game)
        {
            winningStreak++;
            int bonus = winningStreak >= 3 ? 5 : 0; // Наприклад, додаткові очки за виграшну серію з трьох і більше
            CurrentRating += game.CalculateRating() + bonus;
            game.Result = "Win";
            gameHistory.Add(game);
        }

        public override void LoseGame(BaseGame game)
        {
            winningStreak = 0; // Скидаємо серію при програші
            CurrentRating -= game.CalculateRating();
            game.Result = "Lose";
            gameHistory.Add(game);
        }
    }
}
