using GameNamespace;
using GameAccountNamesspace;

public class DbContext
{
    // Список акаунтів
    public List<GameAccount> Accounts { get; set; }

    // Список ігор
    public List<BaseGame> Games { get; set; }

    // Конструктор для наповнення початковими даними
    public DbContext()
    {
        Accounts = new List<GameAccount>();
        Games = new List<BaseGame>();

        // Наповнення бази початковими даними
        SeedData();
    }

    private void SeedData()
    {
        // Додавання акаунтів
        Accounts.Add(new StandardAccount(1, "Player1"));
        Accounts.Add(new DoubleLossAccount(2, "Player2"));
        Accounts.Add(new WinningStreakAccount(3, "Player3"));

        // Додавання ігор
        Games.Add(new StandardGame(1, 10, "Player2"));
        Games.Add(new OneSideGame(2, 15, "Player3") { isRatingForPlayer1 = true });
        Games.Add(new TrainingGame(3, 0, "Player1"));

    }
}
