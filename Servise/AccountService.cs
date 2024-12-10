using GameAccountNamesspace;
public class AccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public void CreateAccount(GameAccount account)
    {
        _accountRepository.CreateAccount(account);
    }

    public GameAccount GetAccountById(int id)
    {
        return _accountRepository.GetAccountById(id);
    }

    public IEnumerable<GameAccount> GetAllAccounts()
    {
        return _accountRepository.GetAllAccounts();
    }

    public void UpdateAccount(GameAccount account)
    {
        _accountRepository.UpdateAccount(account);
    }

    public void DeleteAccount(int id)
    {
        _accountRepository.DeleteAccount(id);
    }
}