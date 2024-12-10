namespace GameNamespace
{
    public abstract class BaseGame
    {
        public int GameTypeId { get; set; }
        private static int UnicId = 1;
        public int GameId { get; private set; }
        public string OpponentName { get; set; }
       public string? Result { get; set; }
        public int Rating { get; set; }

      public BaseGame(int gameTypeId, int rating, string opponentName)
        {
            GameTypeId = gameTypeId;
            OpponentName = opponentName;
            Rating = rating;
            GameId = UnicId++;
            Result = "Unspecified"; // Ініціалізація значення за замовчуванням для Result
        }

        public abstract int CalculateRating();
    }
}
