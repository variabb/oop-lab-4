using GameAccountNamesspace;

public class AccountRepository : IAccountRepository
{
   private readonly DbContext _context;

    // Конструктор, приймає DbContext для роботи з даними
    public AccountRepository(DbContext context)
    {
        _context = context;
    }

      // Додавання нового акаунта
    public void CreateAccount(GameAccount account)
    {
        _context.Accounts.Add(account);  // додаємо акаунт у список
    }

  // Отримати акаунт за id
  public GameAccount GetAccountById(int id)
{
    var account = _context.Accounts.FirstOrDefault(a => a.Id == id);
    if (account == null)
    {
        throw new InvalidOperationException("Account not found");
    }
    return account;
} 
     // Отримання всіх акаунтів
      public IEnumerable<GameAccount> GetAllAccounts()
    {
        return _context.Accounts;  // повертаємо всі акаунти
    }
    // Оновлення акаунта
    public void UpdateAccount(GameAccount account)
    {
        var existingAccount = GetAccountById(account.Id);  // шукаємо існуючий акаунт
        if (existingAccount != null)
        {
            existingAccount.UserName = account.UserName;  // оновлюємо дані акаунта
        }
    }
    // Видалення акаунта
    public void DeleteAccount(int id)
    {
        var account = GetAccountById(id);  // знаходимо акаунт за ID
        if (account != null)
        {
            _context.Accounts.Remove(account);  // видаляємо акаунт
        }
    }
}