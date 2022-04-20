namespace MyLibrary.lib;

public class Library
{
    public static Dictionary<string, ILibraryItem> LibraryItemList = new Dictionary<string, ILibraryItem>();

    public static Dictionary<int, Account> AccountList;

    public Library(IAccountStorageService storage)
    {
        AccountList = new Dictionary<int, Account>();
    }

    public static void SearchLibraryItems(string RequestedItem, Dictionary<string, ILibraryItem> LibraryItemList)
    {
        foreach (KeyValuePair<string, ILibraryItem> item in LibraryItemList)
        {
            if (item.Value.Title == RequestedItem)
            {
                Console.WriteLine(item.Value.GetDetails().ToString());
            }
            else
            {
                Console.WriteLine(LibraryItemList[RequestedItem].GetDetails());
            }
        }
    }

    public static void DisplayLibraryItems(Dictionary<string, ILibraryItem> LibraryItemList)
    {
        foreach (KeyValuePair<string, ILibraryItem> item in LibraryItemList)
        {
            Console.WriteLine(item.Value.GetDetails());
        }
    }

    public static void DisplayPatrons()
    {
        var accountData = File.ReadAllText("accounts.json");
        string[] accountList = accountData.Split(",");
        foreach (string account in accountList)
        {
            Console.WriteLine(account);
        }
    }

    public static void DisplayLibraryItems()
    {
        var itemData = File.ReadAllText("items.json");
        string[] items = itemData.Split(",");
        string trimmeditems = itemData.Trim(new char[] { ':', '{', '}' });
        foreach (string item in items)
        {
            Console.WriteLine(item.Trim(new Char[] { ':', '{', '}' }));
            Console.WriteLine(trimmeditems);
        }
    }
}