using GameAccountNamesspace;

public interface IAccountRepository
{
    void CreateAccount(GameAccount account);
    GameAccount GetAccountById(int id);
    IEnumerable<GameAccount> GetAllAccounts();
    void UpdateAccount(GameAccount account);
    void DeleteAccount(int id);
}