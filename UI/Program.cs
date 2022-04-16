// CS1410 Final Project
// Library App
// Dusty Shaw

using MyLibrary.lib;

namespace MyLibrary
{
    internal partial class Program
    {

        static void Main(string[] args)
        {
            ItemsJsonFileStorageService itemStorage = new ItemsJsonFileStorageService();
            AccountJsonFileStorageService accountStorage = new AccountJsonFileStorageService();

            Library SnowCollegeLibrary = new Library(accountStorage);

            bool programRunning = true;
            while (programRunning == true)
            {
                Console.WriteLine(@"Welcome to the Library App where library workers can keep track of library items,
            check out library items, renew them, and add library patrons.");
                Console.WriteLine("Enter in one of the following commands (ex. to check out a book, enter the word 'CheckOut'):");
                Console.WriteLine(@"
                1. CheckOut
                2. CheckIn
                3. Renew 
                4. AddLibraryItem 
                5. AddNewPatron
                6. SearchLibraryItems
                7. DisplayLibraryItems
                8. DisplayPatrons
                9. Exit -- Exits program
                ");

                var UserInput = Console.ReadLine();
                if (UserInput != "Exit")
                {

                    if (UserInput == "CheckOut")
                    {
                        Console.WriteLine("Enter Item CallNumber to check out: ");
                        string userInputBook = (Console.ReadLine());
                        int userInputID;
                        while (true)
                        {
                            Console.WriteLine("Enter Item patrons ID");
                            try
                            {
                                userInputID = Account.ParsePatronID(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Invalid input");
                            }
                        }

                        var requestedAccount = Library.AccountList[userInputID];  //grabs account from list
                        var RequestedItem = (ILibraryItem)Library.LibraryItemList[userInputBook];  //converts item to icheckoutable and grabs item from libraryItem list
                        Console.WriteLine(RequestedItem.CheckOut(RequestedItem, requestedAccount)); //checkout returns a confirmation that item is checked out

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "CheckIn")
                    {
                        Console.WriteLine("Enter Item CallNumber to check in: ");
                        string RequestedCallNumber = Console.ReadLine();
                        Console.WriteLine("Enter Account Id: ");
                        var userInputID = Convert.ToInt32(Console.ReadLine());
                        var requestedAccount = Library.AccountList[userInputID];  //grabs account
                        var RequestedItem = (ILibraryItem)Library.LibraryItemList[RequestedCallNumber];  //grabs item from list
                        Console.WriteLine(RequestedItem.CheckIn(RequestedItem, requestedAccount));      //checks it in using ILibraryItem check in method

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "Renew")
                    {
                        Console.WriteLine("Enter Item CallNumber to renew: ");
                        string RequestedCallNumber = Console.ReadLine();
                        var RequestedItem = (ILibraryItem)Library.LibraryItemList[RequestedCallNumber];
                        Console.WriteLine(RequestedItem.Renew(RequestedItem));

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "AddLibraryItem")
                    {
                        Console.WriteLine("Select Item Type:");
                        Console.WriteLine("\n Book \n CD \n OversizedBook \n ");
                        string BookType = Console.ReadLine();
                        bool AskingForType = true;
                        while (AskingForType == true)
                        {
                            switch (BookType)
                            {
                                case "Book":
                                    string CallNumber;
                                    while (true)
                                    {
                                        Console.WriteLine("Enter Item CallNumber.  This is usually found in the front cover of your book (ex. 578.3S)");
                                        try
                                        {
                                            CallNumber = ILibraryItem.ParseCallNumbers(Console.ReadLine());
                                            break;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Invalid CallNumber");
                                        }
                                    }
                                    Console.WriteLine("Enter Item Title");
                                    string Title = Console.ReadLine();
                                    Console.WriteLine("Enter Authors Full Name");
                                    string Author = Console.ReadLine();
                                    Int64 ISBN;
                                    while (true)
                                    {
                                        Console.WriteLine("Enter ISBN");
                                        try
                                        {
                                            ISBN = Book.ParseISBN(Console.ReadLine());
                                            break;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("invalid ISBN.  Must be 10 or 13 digits.");
                                        }
                                    }

                                    Int64 Barcode;
                                    while (true)
                                    {
                                        Console.WriteLine("Enter Barcode");
                                        try
                                        {
                                            Barcode = Book.ParseBarcodes(Console.ReadLine());
                                            break;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("invalid Barcode.  Must be 12 digits.");
                                        }
                                    }

                                    Book NewBookItem = new Book(CallNumber, Title, ISBN, Author, Barcode);
                                    Library.LibraryItemList.Add(CallNumber, NewBookItem);

                                    NewBookItem.WriteToTextFile(NewBookItem);

                                    Console.WriteLine($" \n One {NewBookItem.Type} added: " + NewBookItem.GetDetails());

                                    Console.WriteLine("Press Enter to continue");
                                    Console.ReadLine();
                                    AskingForType = false;
                                    break;

                                case "OversizedBook":
                                    string OVCallNumber;
                                    while (true)
                                    {
                                        Console.WriteLine("Enter Item CallNumber.  This is usually found in the front cover of your book (ex. 578.3S)");
                                        try
                                        {
                                            OVCallNumber = ILibraryItem.ParseCallNumbers(Console.ReadLine());
                                            break;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Invalid CallNumber");
                                        }
                                    }
                                    Console.WriteLine("Enter Item Title");
                                    string OVTitle = Console.ReadLine();
                                    Console.WriteLine("Enter Authors Full Name");
                                    string OVAuthor = Console.ReadLine();

                                    Int64 OVISBN;
                                    while (true)
                                    {
                                        Console.WriteLine("Enter ISBN");
                                        try
                                        {
                                            OVISBN = Book.ParseISBN(Console.ReadLine());
                                            break;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("invalid ISBN.  Must be 10 or 13 characters.");
                                        }
                                    }

                                    Console.WriteLine("Enter Barcode");
                                    Int64 OVBarcode = Convert.ToInt64(Console.ReadLine());

                                    //logic
                                    Book OVNewBookItem = new Book(OVCallNumber, OVTitle, OVISBN, OVAuthor, OVBarcode);
                                    Library.LibraryItemList.Add(OVCallNumber, OVNewBookItem);

                                    // Write to text file
                                    OVNewBookItem.WriteToTextFile(OVNewBookItem);
                                    Console.WriteLine($" \n One {OVNewBookItem.Type} added: " + OVNewBookItem.GetDetails());

                                    Console.WriteLine("Press Enter to continue");
                                    Console.ReadLine();
                                    AskingForType = false;
                                    break;

                                case "CD":
                                    string CDCallNumber;
                                    while (true)
                                    {
                                        Console.WriteLine("Enter Item CallNumber.  This is usually found in the front cover of your book (ex. 578.3S)");
                                        try
                                        {
                                            CDCallNumber = ILibraryItem.ParseCallNumbers(Console.ReadLine());
                                            break;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Invalid CallNumber");
                                        }
                                    }
                                    Console.WriteLine("Enter Barcode");
                                    Int64 CDBarcode = Convert.ToInt64(Console.ReadLine());
                                    Console.WriteLine("Enter Item Title");
                                    string CDTitle = Console.ReadLine();
                                    Console.WriteLine("Enter Artist Name");
                                    string CDAuthor = Console.ReadLine();

                                    //logic
                                    CD NewCDItem = new CD(CDCallNumber, CDTitle, CDAuthor, CDBarcode);
                                    Library.LibraryItemList.Add(CDCallNumber, NewCDItem);
                                    Console.WriteLine($" \n one {NewCDItem.Type} added: " + NewCDItem.GetDetails());

                                    Console.WriteLine("Press Enter to continue");
                                    Console.ReadLine();
                                    AskingForType = false;
                                    break;
                            }
                            itemStorage.SaveItems(Library.LibraryItemList);
                        }
                    }

                    if (UserInput == "AddNewPatron")
                    {
                        Console.WriteLine("Enter Patrons First Name: ");
                        string FName = Console.ReadLine();
                        Console.WriteLine("Enter Patrons Last Name: ");
                        string LName = Console.ReadLine();
                        Console.WriteLine("Enter Patrons ID");
                        int PatronID = Convert.ToInt32(Console.ReadLine());

                        //logic
                        Account newAccount = new Account(FName, LName, PatronID);
                        Library.AccountList.Add(PatronID, newAccount);

                        Console.WriteLine("New Patron Added: " + newAccount.GetAccountDetails());

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "SearchLibraryItems")
                    {
                        Console.WriteLine("Enter in Call Number or Title");
                        string RequestedItem = Console.ReadLine();

                        Library.SearchLibraryItems(RequestedItem, Library.LibraryItemList);

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "DisplayLibraryItems")
                    {
                        Library.DisplayLibraryItems(Library.LibraryItemList);
                        SnowCollegeLibrary.ReadTextFile();

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "DisplayPatrons")
                    {
                        Library.DisplayPatrons(Library.AccountList);

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    else { }
                }

                else
                {
                    Console.WriteLine("Goodbye!");
                    programRunning = false;
                }
            }
        }
    }
}
