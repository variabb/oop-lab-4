using GameNamespace;
public interface IGameRepository
{
    void CreateGame(BaseGame game);
    BaseGame GetGameById(int id);
    IEnumerable<BaseGame> GetAllGames();
    void UpdateGame(BaseGame game);
    void DeleteGame(int id);
}