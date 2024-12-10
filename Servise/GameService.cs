using GameNamespace;
public class GameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public void CreateGame(BaseGame game)
    {
        _gameRepository.CreateGame(game);
    }

    public BaseGame GetGameById(int id)
    {
        return _gameRepository.GetGameById(id);
    }

    public IEnumerable<BaseGame> GetAllGames()
    {
        return _gameRepository.GetAllGames();
    }

    public void UpdateGame(BaseGame game)
    {
        _gameRepository.UpdateGame(game);
    }

    public void DeleteGame(int id)
    {
        _gameRepository.DeleteGame(id);
    }
}