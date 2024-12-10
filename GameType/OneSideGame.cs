using GameNamespace;

namespace GameNamespace
{
    public class OneSideGame : BaseGame
    {
        public bool isRatingForPlayer1;
        public OneSideGame(int gameTypeId, int rating, string opponentName)
            : base(gameTypeId, rating, opponentName) 
        {
        }

      

    public override int CalculateRating() 
    {
        if (isRatingForPlayer1) 
        {
            // Рейтинг змінюється тільки для гравця 1
            return Rating;
        }
        else 
        {
            // Рейтинг не змінюється для опонента
            return 0; 
        }
    }
    }
}
