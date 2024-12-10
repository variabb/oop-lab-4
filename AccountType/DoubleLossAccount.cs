using GameNamespace;

namespace GameAccountNamesspace
{
    public class DoubleLossAccount : GameAccount
    {
        public DoubleLossAccount(int id, string userName) : base(id, userName) {}

        public override void WinGame(BaseGame game)
        {
            game.Result = "Win";
            Rating += game.CalculateRating();
            gameHistory.Add(game);
        }

        public override void LoseGame(BaseGame game)
        {
            game.Result = "Lose";
            Rating -= game.CalculateRating() * 2; // Подвійний штраф
            if (Rating < 1) Rating = 1;
            gameHistory.Add(game);
        }
    }
}
