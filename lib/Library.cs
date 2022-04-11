namespace MyLibrary.lib;

public class Library
{
    public Dictionary<string, ICheckoutable> LibraryItemList = new Dictionary<string, ICheckoutable>();
    public List<Account> accounts = new List<Account>();
    public Library(IAccountStorageService storage)
    {
        List<Account> accounts = new List<Account>();
    }

    public ICheckoutable AddItem(ICheckoutable item)
    {
        throw new Exception();
    }

    public ICheckoutable AddAccount(ICheckoutable item)
    {
        throw new Exception();
    }

    public void SaveAccounts()
    {
        //TextFileStorageService.SaveAccounts(accounts);
    }

    public static void SearchLibraryItems(string RequestedItem, Dictionary<string, ICheckoutable> LibraryItemList)
    {
        foreach (KeyValuePair<string, ICheckoutable> item in LibraryItemList)
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
}