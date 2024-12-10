using GameNamespace;
using System;
using System.Data.Common;

namespace GameAccountNamesspace
{
    public class StandardAccount : GameAccount
    {
        public StandardAccount(int id, string userName) : base(id, userName) { } // конструктор

        public override void WinGame(BaseGame game)
        {
            game.Result = "Win";
            Rating += game.CalculateRating();
            gameHistory.Add(game);
        }

        public override void LoseGame(BaseGame game)
        {
            game.Result = "Lose";
            Rating -= game.CalculateRating();
            if (Rating < 1) Rating = 1;
            gameHistory.Add(game);
        }
    }
}
