namespace MyLibrary.lib;

public class Library
{
    public Dictionary<string, ILibraryItem> LibraryItemList ;

    public Dictionary<int, Account> AccountList;

    public Dictionary<string, Book> BookList;

    public Dictionary<string, CD> CDList;

    public Dictionary<string, OversizedBook> OversizedBookList;

    private readonly IItemStorageService itemStorage;

    public Library(IAccountStorageService storage, IItemStorageService itemStorage)
    {
        LibraryItemList = new Dictionary<string, ILibraryItem>();
        AccountList = new Dictionary<int, Account>();

        BookList = itemStorage.LoadBooks();
        CDList = itemStorage.LoadCDs();
        OversizedBookList = itemStorage.LoadOversizedBooks();
        
        this.itemStorage = itemStorage;
    }

    //looks through each library item and checks if the title or the call number given matches any items in the list
    public void SearchLibraryItems(string RequestedItem, Dictionary<string, ILibraryItem> LibraryItemList)
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

    //this method was for when my library items were not being stored in a json file and just in a dictionary that would reset every time the program ran.
    public void DisplayLibraryItems(Dictionary<string, ILibraryItem> LibraryItemList)
    {
        foreach (KeyValuePair<string, ILibraryItem> item in LibraryItemList)
        {
            Console.WriteLine(item.Value.GetDetails());
        }
        
    }

    public void DisplayPatrons()
    {
        var accountData = File.ReadAllText("accounts.json");
        string[] accountList = accountData.Split(",");
        foreach (string account in accountList)
        {
            Console.WriteLine(account);
            
        }
    }

    public void RenewItem(string RequestedCallNumber, Library SnowCollegeLibrary)
    {
        var RequestedItem = (ILibraryItem)SnowCollegeLibrary.LibraryItemList[RequestedCallNumber];
        Console.WriteLine(RequestedItem.Renew(RequestedItem));
    }

    public void CheckInItem(string RequestedCallNumber, int userInputID, Library SnowCollegeLibrary)
    {
        var requestedAccount = SnowCollegeLibrary.AccountList[userInputID];  //grabs account
        var RequestedItem = (ILibraryItem)SnowCollegeLibrary.LibraryItemList[RequestedCallNumber];  //grabs item from list
        Console.WriteLine(RequestedItem.CheckIn(RequestedItem, requestedAccount));      //checks it in using ILibraryItem check in method
    }

    public void CheckOutItem(int userInputID, string userInputBook, Library SnowCollegeLibrary)
    {
        var requestedAccount = SnowCollegeLibrary.AccountList[userInputID];  //grabs account from list
        var RequestedItem = (ILibraryItem)SnowCollegeLibrary.LibraryItemList[userInputBook];  //converts item to icheckoutable and grabs item from libraryItem list
        Console.WriteLine(RequestedItem.CheckOut(RequestedItem, requestedAccount)); //checkout returns a confirmation that item is checked out
    }

    public void SaveBooks()
    {
        itemStorage.SaveBooks(BookList);
    }

    public void SaveCDs()
    {
        itemStorage.SaveCDs(CDList);
    }

    public void SaveOversizedBooks()
    {
        itemStorage.SaveOversizedBooks(OversizedBookList);
    }

    public Dictionary<string, Book> LoadBooks()
    {
        return itemStorage.LoadBooks();
    }

    public Dictionary<string, OversizedBook> LoadOVBooks()
    {
        return itemStorage.LoadOversizedBooks();
    }

}