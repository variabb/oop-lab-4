using GameAccountNamesspace;
using GameNamespace;
using Factory;
using System;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо екземпляр DbContext (імітуємо базу даних)
            var context = new DbContext();

            // Створюємо репозиторії для акаунтів та ігор
            var accountRepository = new AccountRepository(context);
            var gameRepository = new GameRepository(context);

     // -------------------Створюємо фабрику для створення ігор
            var gameFactory = new GameFactory(gameRepository);

     // -------------------- Створюємо кілька акаунтів
            var standardAccount = new StandardAccount(4, "Player4");
            var doubleLossAccount = new DoubleLossAccount(5, "Player5");
            var winningStreakAccount = new WinningStreakAccount(6, "Player6");

     // ------------------ Додаємо акаунти в базу даних
            accountRepository.CreateAccount(standardAccount);
            accountRepository.CreateAccount(doubleLossAccount);
            accountRepository.CreateAccount(winningStreakAccount);

            

    //---------------------- Імітація ігор
            PlayGame(standardAccount, doubleLossAccount, gameFactory.CreateGame(GameType.Standard, "john", 10));
            PlayGame(standardAccount, doubleLossAccount, gameFactory.CreateGame(GameType.Standard, "john", 15));
            PlayGame(standardAccount, doubleLossAccount, gameFactory.CreateGame(GameType.Standard, "john", 20));
            PlayGame(doubleLossAccount, winningStreakAccount, gameFactory.CreateGame(GameType.Training, "mango"));
            PlayGame(winningStreakAccount, standardAccount, gameFactory.CreateGame(GameType.OneSide, "Varia", 10));

    //------------------- Виведення статистики гравців
            standardAccount.GetStats();
            doubleLossAccount.GetStats();
            winningStreakAccount.GetStats();


       
    // ----------------------- Виводимо всі акаунти
    Console.WriteLine("All accounts:");
    var allAccounts = accountRepository.GetAllAccounts(); // Отримуємо всі акаунти
    foreach (var account in allAccounts)
    {
        Console.WriteLine($"ID: {account.Id}, UserName: {account.UserName}");
    }

    //--------------------- Пошук акаунта за його id
    var PlayerAccount = accountRepository.GetAccountById(3); // Отримуємо акаунт
    try{Console.WriteLine($"Account found: ID: {PlayerAccount.Id}, UserName: {PlayerAccount.UserName}");}
     catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message); // Якщо акаунт не знайдено
    }
    
    // ------------------------- Оновлення акаунта
    int accountIdToUpdate = 5; // ID акаунта, який ми хочемо оновити
    try
    {
        var accountToUpdate = accountRepository.GetAccountById(accountIdToUpdate);
        Console.WriteLine($"Before update: ID: {accountToUpdate.Id}, UserName: {accountToUpdate.UserName}");

        accountToUpdate.UserName = "UpdatedPlayer5";
        accountRepository.UpdateAccount(accountToUpdate);
        var updatedAccount = accountRepository.GetAccountById(accountIdToUpdate);
        Console.WriteLine($"After update: ID: {updatedAccount.Id}, UserName: {updatedAccount.UserName}");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message); // Якщо акаунт не знайдено
    }

    //---------------------------- Видалення акаунта
    int accountIdToDelete = 6; 
    try
    {
        accountRepository.DeleteAccount(accountIdToDelete);
        Console.WriteLine($"\nAccount with ID {accountIdToDelete} has been deleted.");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message); // Якщо акаунт не знайдено
    }

    // Виведемо всі акаунти після видалення
    Console.WriteLine("\nAccounts after deletion:");
    foreach (var account in accountRepository.GetAllAccounts())
    {
        Console.WriteLine($"ID: {account.Id}, UserName: {account.UserName}");
    }

    }

        static void PlayGame(GameAccount player1, GameAccount player2, BaseGame game)
        {
            Random rand = new Random();
            bool playerWins = rand.NextDouble() > 0.5;

            if (playerWins)
            {
                player1.WinGame(game);
                player2.LoseGame(game);
            }
            else
            {
                player1.LoseGame(game);
                player2.WinGame(game);
            }
        }
    }
}
