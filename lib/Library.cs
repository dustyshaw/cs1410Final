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
    public string SearchLibraryItems(string RequestedItem, Dictionary<string, ILibraryItem> LibraryItemList)
    {
        foreach (KeyValuePair<string, ILibraryItem> item in LibraryItemList)
        {
            if (item.Value.Title == RequestedItem)
            {
                return item.Value.GetDetails().ToString();
            }
            if (item.Key == RequestedItem)
            {
                return LibraryItemList[RequestedItem].GetDetails();
            }
        }
        return "";
    }

    //this method was for when my library items were not being stored in a json file and just in a dictionary that would reset every time the program ran.
    public string DisplayLibraryItems(Dictionary<string, ILibraryItem> LibraryItemList)
    {
        foreach (KeyValuePair<string, ILibraryItem> item in LibraryItemList)
        {
            return item.Value.GetDetails();
        }
        return "";
    }

    public string DisplayPatrons()
    {
        var accountData = File.ReadAllText("accounts.json");    //reads from json file and returns account objects
        string[] accountList = accountData.Split(",");          //puts text into a string array, splitting each line by a comma
        foreach (string account in accountList)
        {
            return account;
        }
        return "";
    }

    public string RenewItem(string RequestedCallNumber, Library SnowCollegeLibrary)
    {
        var RequestedItem = (ILibraryItem)SnowCollegeLibrary.LibraryItemList[RequestedCallNumber];  //grabs item by call number and casts it as a generic lib item
        return RequestedItem.Renew(RequestedItem);                                      
    }

    public string CheckInItem(string RequestedCallNumber, int userInputID, Library SnowCollegeLibrary)
    {
        var requestedAccount = SnowCollegeLibrary.AccountList[userInputID];                         //grabs account
        var RequestedItem = (ILibraryItem)SnowCollegeLibrary.LibraryItemList[RequestedCallNumber];  //grabs item from list
        return RequestedItem.CheckIn(RequestedItem, requestedAccount);                  //checks item in using ILibraryItem check in method
    }

    public string CheckOutItem(int userInputID, string userInputBook, Library SnowCollegeLibrary)
    {
        var requestedAccount = SnowCollegeLibrary.AccountList[userInputID];                     //grabs account from list
        var RequestedItem = (ILibraryItem)SnowCollegeLibrary.LibraryItemList[userInputBook];    //converts item to icheckoutable and grabs item from libraryItem list
        return RequestedItem.CheckOut(RequestedItem, requestedAccount);                         //checkout returns a confirmation that item is checked out
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