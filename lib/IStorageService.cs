namespace MyLibrary.lib;

public interface IAccountStorageService
{
    public void SaveAccounts(Dictionary<int, Account> accounts);
    public Dictionary<int, Account> LoadAccounts();
}

public class AccountJsonFileStorageService : IAccountStorageService
{
    public Dictionary<int, Account> LoadAccounts()
    {
        if (File.Exists("accounts.json"))
        {
            var json = File.ReadAllText("accounts.json");
            return System.Text.Json.JsonSerializer.Deserialize<Dictionary<int, Account>>(json);
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

public class ItemsJsonFileStorageService : IItemStorageService
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
        // if (!File.Exists("items.json"))
        // {
        //     File.Create("items.json");
        // }

        //{
        var json = System.Text.Json.JsonSerializer.Serialize(LibraryItem);
        File.WriteAllText("items.json", json);
        //}
    }
}

public class BookJsonFileStorageService
{
    public Dictionary<string, Book> LoadItems()
    {
        if (File.Exists("books.json"))
        {
            var json = File.ReadAllText("books.json");
            Library.BookList = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, Book>>(json);
        }
        return Library.BookList;
    }

    public void SaveItems(Dictionary<string, Book> Books)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(Books);
        File.WriteAllText("books.json", json);
    }
}