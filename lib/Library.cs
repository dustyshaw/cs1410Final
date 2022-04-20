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

    public static void DisplayPatrons(Dictionary<int, Account> AccountList)
    {
        foreach (KeyValuePair<int, Account> item in AccountList)
        {
            Console.WriteLine(item.Value.GetAccountDetails());
        }
    }

    // public async void ReadTextFile()
    // {
    //     string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");
    //     System.Console.WriteLine("Contents of data.txt = ");
    //     foreach (string line in lines)
    //     {
    //         // Use a tab to indent each line of the file.
    //         Console.WriteLine("\t" + line);
    //     }
    // }

}