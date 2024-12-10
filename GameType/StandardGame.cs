using GameNamespace;

namespace GameNamespace
{
    public class StandardGame : BaseGame
    {
        public StandardGame(int gameTypeId, int rating, string opponentName)
            : base(gameTypeId, rating, opponentName) // Передаємо rating до конструктора BaseGame
        {
        }

        public override int CalculateRating()
        {
            return Rating; // Приклад реалізації
        }
    }
}