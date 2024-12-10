using GameNamespace;

namespace GameNamespace
{
    public class TrainingGame : BaseGame
    {
       public TrainingGame(int gameTypeId, int rating, string opponentName)
            : base(gameTypeId, rating, opponentName) 
        {
        }

        public override int CalculateRating()
        {
            return 0; // У тренувальних іграх рейтинг не змінюється
        }
    }
}
