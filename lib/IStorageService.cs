

namespace MyLibrary.lib;

//whenever you make a library.cs, you need to pass in a Istorage service

public interface IAccountStorageService
{
    public void SaveAccounts(IEnumerable<Account> accounts);
    public IEnumerable<Account> LoadAccounts();
}

public class AccountJsonFileStorageService : IAccountStorageService
{
    List<Account> accounts = new List<Account>();
    public IEnumerable<Account> LoadAccounts()
    {
        //Account.Clear(); //accounts is a list of accounts. this should be in library.cs.  
        // accounts.AddRange(storageService.LoadAccounts();)
        // if (File.Exists("accounts.txt"))
        // {
        //     accounts = Account.Load("accounts.txt");
        // }
        if(File.Exists("accounts.json"))
        {
            var json = File.ReadAllText("accounts.json");
            accounts = System.Text.Json.JsonSerializer.Deserialize<List<Account>>(json);
        }
        return accounts;
    }

    public void SaveAccounts(IEnumerable<Account> accounts)
    {
        // using (var writer = new StreamWriter("accounts.txt"))
        // {
        //     foreach (var account in accounts)
        //     {
        //         account.Save(writer);
        //     }
        //     writer.Close();
        // }   
        var json = System.Text.Json.JsonSerializer.Serialize(accounts);
        File.WriteAllText("accounts.json", json);
    }
}

// public class ItemsJsonFileStorageService : IAccountStorageService
// {
//      Dictionary<string, ICheckoutable> LibraryItemList = new Dictionary<string, ICheckoutable>();
//     public Dictionary<string, ICheckoutable> LoadItems()
//     {
//         if(File.Exists("accounts.json"))
//         {
//             var json = File.ReadAllText("accounts.json");
//             LibraryItemList = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, ICheckoutable>>(json);
//         }
//         return LibraryItemList<string, ICheckoutable>;
//     }

//     public void SaveAccounts(Dictionary<string, ICheckoutable> LibraryItem)
//     {
//         var json = System.Text.Json.JsonSerializer.Serialize(accounts);
//         File.WriteAllText("accounts.json", json);
//     }
// }

//in library class, make a public reference field to the 

