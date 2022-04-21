namespace MyLibrary.lib;

public class Library
{
    public static Dictionary<string, ILibraryItem> LibraryItemList = new Dictionary<string, ILibraryItem>();

    public static Dictionary<int, Account> AccountList;

    public static Dictionary<string, Book> BookList;

    public static Dictionary<string, CD> CDList;

    public static Dictionary<string, OversizedBook> OversizedBookList;

    public Library(IAccountStorageService storage)
    {
        AccountList = new Dictionary<int, Account>();
        BookList = new Dictionary<string, Book>();
        CDList = new Dictionary<string, CD>();
        OversizedBookList = new Dictionary<string, OversizedBook>();
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


    public static void RenewItem(string RequestedCallNumber)
    {
        var RequestedItem = (ILibraryItem)Library.LibraryItemList[RequestedCallNumber];
        Console.WriteLine(RequestedItem.Renew(RequestedItem));
    }

    public static void CheckInItem(string RequestedCallNumber, int userInputID)
    {
        var requestedAccount = Library.AccountList[userInputID];  //grabs account
        var RequestedItem = (ILibraryItem)Library.LibraryItemList[RequestedCallNumber];  //grabs item from list
        Console.WriteLine(RequestedItem.CheckIn(RequestedItem, requestedAccount));      //checks it in using ILibraryItem check in method
    }

    public static void CheckOutItem(int userInputID, string userInputBook)
    {
        var requestedAccount = Library.AccountList[userInputID];  //grabs account from list
        var RequestedItem = (ILibraryItem)Library.LibraryItemList[userInputBook];  //converts item to icheckoutable and grabs item from libraryItem list
        Console.WriteLine(RequestedItem.CheckOut(RequestedItem, requestedAccount)); //checkout returns a confirmation that item is checked out
    }

    public static void SaveAllItems(CDJsonFileStorageService CDStorage, BookJsonFileStorageService bookStorage, OversizedBookJsonFileStorageService OVbookStorage)
    {
        //itemStorage.SaveItems(Library.LibraryItemList);
        CDStorage.SaveItems(Library.CDList);
        bookStorage.SaveItems(Library.BookList);
        OVbookStorage.SaveItems(Library.OversizedBookList);
    }
}