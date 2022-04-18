namespace MyLibrary.lib;

//whenever you make a library.cs, you need to pass in a Istorage service

public interface IAccountStorageService
{
    public void SaveAccounts(Dictionary<int, Account> accounts);
    public Dictionary<int, Account> LoadAccounts();
}

public class AccountJsonFileStorageService : IAccountStorageService
{
    //List<Account> accounts = new List<Account>();
    public Dictionary<int, Account> LoadAccounts()
    {
        if (File.Exists("accounts.json"))
        {
            var json = File.ReadAllText("accounts.json");
            return System.Text.Json.JsonSerializer.Deserialize<Dictionary<int,Account>>(json);
        }
        return new Dictionary<int, Account>();
    }

    public void SaveAccounts(Dictionary<int, Account> accounts)
    {
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
        if (File.Exists("items.json"))
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

