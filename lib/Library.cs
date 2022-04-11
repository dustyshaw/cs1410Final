namespace MyLibrary.lib;

public class Library
{
    public Dictionary<string, ILibraryItem> LibraryItemList = new Dictionary<string, ILibraryItem>();
    
    public List<Account> accounts = new List<Account>();

    public Library(IAccountStorageService storage)
    {
        List<Account> accounts = new List<Account>();
    }

    public ILibraryItem AddItem(ILibraryItem item)
    {
        throw new Exception();
    }

    public ILibraryItem AddAccount(ILibraryItem item)
    {
        throw new Exception();
    }

    public void SaveAccounts()
    {
        //TextFileStorageService.SaveAccounts(accounts);
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

    public static void DisplayPatrons(Dictionary<int, Account> AccountList)
    {
        foreach (KeyValuePair<int, Account> item in AccountList)
        {
            Console.WriteLine(item.Value.GetAccountDetails());
        }
    }
}