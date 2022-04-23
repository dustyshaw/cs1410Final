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
    void SaveBooks(Dictionary<string, Book> books);
    Dictionary<string, Book> LoadBooks();

    void SaveCDs(Dictionary<string, CD> cds);
    Dictionary<string, CD> LoadCDs();

    void SaveOversizedBooks(Dictionary<string, OversizedBook> oversizedbooks);
    Dictionary<string, OversizedBook> LoadOversizedBooks();

}

public class ItemsJsonFileStorageService : IItemStorageService
{
    public Dictionary<string, Book> LoadBooks()
    {
        if (File.Exists("books.json"))
        {
            var json = File.ReadAllText("books.json");
            return System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, Book>>(json);
        }
        return new Dictionary<string, Book>();
    }

    public void SaveBooks(Dictionary<string, Book> books)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(books);
        File.WriteAllText("books.json", json);
    }

    public Dictionary<string, CD> LoadCDs()
    {
        if (File.Exists("CDs.json"))
        {
            var json = File.ReadAllText("CDs.json");
            return System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, CD>>(json);
        }
        return new Dictionary<string, CD>();
    }

    public void SaveCDs(Dictionary<string, CD> cds)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(cds);
        if (File.Exists("CDs.json"))
        {
            File.WriteAllText("CDs.json", json);
        }
        else
        {
            File.Create("CDs.json");
            File.WriteAllText("CDs.json", json);
        }
    }

    public Dictionary<string, OversizedBook> LoadOversizedBooks()
    {
        if (File.Exists("OversizedBooks.json"))
        {
            var json = File.ReadAllText("OversizedBooks.json");
            return System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, OversizedBook>>(json);
        }
        return new Dictionary<string, OversizedBook>();
    }

    public void SaveOversizedBooks(Dictionary<string, OversizedBook> oversizedbooks)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(oversizedbooks);
        File.WriteAllText("OversizedBooks.json", json);
    }
}
