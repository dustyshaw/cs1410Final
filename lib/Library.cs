namespace MyLibrary.lib;

public class Library
{
    public Dictionary<string, ILibraryItem> LibraryItemList
    {
        get
        {
            var items = new Dictionary<string, ILibraryItem>();
            foreach (var book in BookList)
            {
                items.Add(book.Key, book.Value);
            }
            foreach (var cd in CDList)
            {
                items.Add(cd.Key, cd.Value);
            }
            foreach (var oversized in OversizedBookList)
            {
                items.Add(oversized.Key, oversized.Value);
            }
            return items;
        }
    }

    public Dictionary<int, Account> AccountList;

    public Dictionary<string, Book> BookList;

    public Dictionary<string, CD> CDList;

    public Dictionary<string, OversizedBook> OversizedBookList;

    private readonly IItemStorageService itemStorage;

    public Library(IAccountStorageService storage, IItemStorageService itemStorage)
    {
        AccountList = new Dictionary<int, Account>();

        BookList = itemStorage.LoadBooks();
        CDList = itemStorage.LoadCDs();
        OversizedBookList = itemStorage.LoadOversizedBooks();

        this.itemStorage = itemStorage;
    }

    //looks through each library item and checks if the title or the call number given matches any items in the list
    public ILibraryItem SearchLibraryItems(string RequestedItem)
    {
        bool keyExists = LibraryItemList.ContainsKey(RequestedItem);

        if (keyExists != true)
        {
            throw new KeyNotFoundException();
        }
        else
        {
           return LibraryItemList[RequestedItem];
        }
    }

    public string DisplayPatrons()
    {
        var accountData = File.ReadAllText("accounts.json");    //reads from json file and returns account objects
        string[] accountList = accountData.Split(",");          //puts text into a string array, splitting each line by a comma
        foreach (string account in accountList)
        {
            return account;
        }
        return accountData;
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