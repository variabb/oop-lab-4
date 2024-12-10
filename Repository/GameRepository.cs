using GameNamespace;
public class GameRepository : IGameRepository
{
    private readonly DbContext _context;

    public GameRepository(DbContext context)
    {
        _context = context;
    }

    public void CreateGame(BaseGame game) => _context.Games.Add(game);
        public BaseGame GetGameById(int id)
    {
        var game = _context.Games.FirstOrDefault(g => g.GameId == id);
        if (game == null)
        {
            throw new InvalidOperationException("Game not found");
        }
        return game;
    }
    public IEnumerable<BaseGame> GetAllGames() => _context.Games;
    public void UpdateGame(BaseGame game)
    {
        var existingGame = GetGameById(game.GameId);
        if (existingGame != null)
        {
            existingGame.OpponentName = game.OpponentName;
            
        }
    }
    public void DeleteGame(int id)
    {
        var game = GetGameById(id);
        if (game != null)
        {
            _context.Games.Remove(game);
        }
    }
}