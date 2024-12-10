using GameNamespace;
using GameAccountNamesspace;
namespace Factory
{
    enum GameType
    {
        Standard,
        Training,
        OneSide
    }

    class GameFactory
    {
        private readonly IGameRepository _gameRepository;

        // Конструктор фабрики приймає IGameRepository для роботи з базою даних
        public GameFactory(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        // Метод створення гри
        public BaseGame CreateGame(GameType gameType, string opponentName, int rating = 0)
        {
            BaseGame game;

            switch (gameType)
            {
                case GameType.Standard:
                    game = new StandardGame(1, rating, opponentName);
                    break;
                case GameType.Training:
                    game = new TrainingGame(2, 0, opponentName);
                    break;
                case GameType.OneSide:
                    game = new OneSideGame(3, rating, opponentName);
                    break;
                default:
                    throw new ArgumentException("Неправильний тип гри");
            }

            // Зберігаємо створену гру в базі даних через репозиторій
            _gameRepository.CreateGame(game);

            // Повертаємо створену гру
            return game;
        }
    }
}

