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

public interface IItemStorageService
{
    public void SaveItems(Dictionary<string, ILibraryItem> LibraryItem);
    public Dictionary<string, ILibraryItem> LoadItems();
}

public class ItemsJsonFileStorageService 
{
     Dictionary<string, ILibraryItem> LibraryItemList = new Dictionary<string, ILibraryItem>();
    public Dictionary<string, ILibraryItem> LoadItems()
    {
        if(File.Exists("items.json"))
        {
            var json = File.ReadAllText("items.json");
            LibraryItemList = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, ILibraryItem>>(json);
        }
        return LibraryItemList;
    }

    public void SaveItems(Dictionary<string, ILibraryItem> LibraryItem)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(LibraryItem);
        File.WriteAllText("items.json", json);
    }
}

//in library class, make a public reference field to the 

