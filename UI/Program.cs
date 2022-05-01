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
            //creating instances of the IStorageService.cs in order to store all types of library items
            ItemsJsonFileStorageService itemStorage = new ItemsJsonFileStorageService();

            AccountJsonFileStorageService accountStorage = new AccountJsonFileStorageService();


            Library SnowCollegeLibrary = new Library(accountStorage, itemStorage);

            bool programRunning = true;
            while (programRunning == true)
            {
                Console.Clear();
                Console.WriteLine(@"Welcome to the Library App where library workers can keep track of library items,
            check out library items, renew them, and add library patrons.");
                Console.WriteLine("Enter in one of the following commands (ex. to check out a book, enter a 1):");
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

                var UserInput = Convert.ToInt32(Console.ReadLine());
                if (UserInput != 9)
                {
                    if (UserInput == 1)
                    {
                        Console.WriteLine("Enter Item CallNumber to check out: ");
                        string RequestedBookCallNumber = (Console.ReadLine());
                        int RequestedAccID;
                        while (true)
                        {
                            Console.WriteLine("Enter Item patrons ID");
                            try
                            {
                                RequestedAccID = Account.ParsePatronID(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Invalid input");
                            }
                        }

                        // Library handles user input entered above and takes care of checking item out
                        SnowCollegeLibrary.CheckOutItem(RequestedAccID, RequestedBookCallNumber, SnowCollegeLibrary);

                        //Library saves all items
                        SnowCollegeLibrary.SaveBooks();
                        SnowCollegeLibrary.SaveCDs();
                        SnowCollegeLibrary.SaveOversizedBooks();

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == 2)
                    {
                        Console.WriteLine("Enter Item CallNumber to check in: ");
                        string RequestedCallNumber = Console.ReadLine();
                        Console.WriteLine("Enter Account Id: ");
                        int userInputID = Convert.ToInt32(Console.ReadLine());

                        SnowCollegeLibrary.CheckInItem(RequestedCallNumber, userInputID, SnowCollegeLibrary);

                        SnowCollegeLibrary.SaveBooks();
                        SnowCollegeLibrary.SaveCDs();
                        SnowCollegeLibrary.SaveOversizedBooks();

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == 3)
                    {
                        Console.WriteLine("Enter Item CallNumber to renew: ");
                        string RequestedCallNumber = Console.ReadLine();

                        SnowCollegeLibrary.RenewItem(RequestedCallNumber, SnowCollegeLibrary);

                        SnowCollegeLibrary.SaveBooks();
                        SnowCollegeLibrary.SaveCDs();
                        SnowCollegeLibrary.SaveOversizedBooks();

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == 4)
                    {
                        Console.WriteLine("Select Item Type:");
                        Console.WriteLine("\n 1. Book \n 2. OversizedBook \n 3. CD \n ");
                        int BookType = Convert.ToInt32(Console.ReadLine());

                        bool AskingForType = true;
                        while (AskingForType == true)
                        {
                            switch (BookType)
                            {
                                case 1:
                                    string CallNumber;
                                    while (true)
                                    {
                                        Console.WriteLine("Enter Item CallNumber.  This is usually found in the front cover of your book (ex. 578.3S)");
                                        try
                                        {
                                            CallNumber = ILibraryItem.ParseCallNumbers(Console.ReadLine(), SnowCollegeLibrary);
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
                                            ISBN = ILibraryItem.ParseISBN(Console.ReadLine());
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
                                            Barcode = ILibraryItem.ParseBarcodes(Console.ReadLine());
                                            break;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("invalid Barcode.  Must be 12 digits.");
                                        }
                                    }

                                    var NewBookItem = BookMaker.BookMakerforLibrary(CallNumber, Title, Author, Barcode, ISBN);
                                    Console.Clear();
                                    Console.WriteLine(NewBookItem.GetDetails() + " \n Enter 'Y' to confirm item details, 'R' to exit and not save item details : ");
                                    var userConfirmation = Console.ReadLine();

                                    while (userConfirmation != "Y" || userConfirmation != "R")
                                    {
                                        if (userConfirmation == "Y")
                                        {
                                            userConfirmation = "Y";

                                            //New book is added to lists and then saved to a file by SnowCollegeLibrary
                                            SnowCollegeLibrary.BookList.Add(NewBookItem.CallNumber, NewBookItem);
                                            SnowCollegeLibrary.SaveBooks();

                                            Console.WriteLine("item Saved");
                                            Console.WriteLine("Press enter to continue");
                                            Console.ReadLine();
                                            AskingForType = false;
                                            break;
                                        }
                                        if (userConfirmation == "R")
                                        {
                                            // Gives the user to exit the block and not saving the book.
                                            userConfirmation = "R";
                                            AskingForType = false;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Not a valid option.  Enter 'Y' to confirm item details, 'R' to exit and not save item details :");
                                            userConfirmation = Console.ReadLine();
                                        }
                                    }
                                    AskingForType = false;
                                    break;

                                case 2:

                                    var OVNewBookItem = OversizedBookMaker.OversizedBookMakerForLibrary(SnowCollegeLibrary);
                                    Console.Clear();

                                    Console.WriteLine(OVNewBookItem.GetDetails() + $"Enter 'Y' to confirm item details, 'R' to exit and not save item details : ");
                                    var OVuserConfirmation = Console.ReadLine();

                                    while (OVuserConfirmation != "Y" || OVuserConfirmation != "R")
                                    {
                                        if (OVuserConfirmation == "Y")
                                        {
                                            OVuserConfirmation = "Y";

                                           //itemStorage.SaveItems(SnowCollegeLibrary.LibraryItemList);

                                            SnowCollegeLibrary.OversizedBookList.Add(OVNewBookItem.CallNumber, OVNewBookItem);
                                            //Library.SaveAllItems(CDStorage, bookStorage, OVbookStorage);

                                            SnowCollegeLibrary.SaveBooks();
                                            SnowCollegeLibrary.SaveCDs();
                                            SnowCollegeLibrary.SaveOversizedBooks();

                                            Console.WriteLine("item Saved");
                                            Console.WriteLine("Press enter to continue");
                                            Console.ReadLine();
                                            AskingForType = false;
                                            break;
                                        }
                                        if (OVuserConfirmation == "R")
                                        {
                                            OVuserConfirmation = "R";
                                            AskingForType = false;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Not a valid option.  Enter 'Y' to confirm item details, 'R' to exit and not save item details :");
                                            OVuserConfirmation = Console.ReadLine();
                                        }
                                    }
                                    AskingForType = false;
                                    break;

                                case 3:
                                    string CDCallNumber;
                                    while (true)
                                    {
                                        Console.WriteLine("Enter Item CallNumber.  This is usually found in the front cover of your book (ex. 578.3S)");
                                        try
                                        {
                                            CDCallNumber = ILibraryItem.ParseCallNumbers(Console.ReadLine(), SnowCollegeLibrary);
                                            break;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Invalid CallNumber");
                                        }
                                    }
                                    Int64 CDBarcode;
                                    while (true)
                                    {
                                        Console.WriteLine("Enter Barcode");
                                        try
                                        {
                                            CDBarcode = ILibraryItem.ParseBarcodes(Console.ReadLine());
                                            break;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("invalid Barcode.  Must be 12 digits.");
                                        }
                                    }
                                    Console.WriteLine("Enter Item Title");
                                    string CDTitle = Console.ReadLine();
                                    Console.WriteLine("Enter Artist Name");
                                    string CDAuthor = Console.ReadLine();

                                    //logic seperated into a "cdmaker" file.  
                                    CD NewCDItem = CDMaker.CDMakerForLibrary(CDTitle, CDAuthor, CDBarcode, CDCallNumber);
                                    Console.Clear();

                                    Console.WriteLine(NewCDItem.GetDetails() + " \n Enter 'Y' to confirm item details, 'R' to exit and not save item details : ");
                                    var CDuserConfirmation = Console.ReadLine();

                                    while (CDuserConfirmation != "Y" && CDuserConfirmation != "R")
                                    {
                                        if (CDuserConfirmation == "Y")
                                        {

                                            CDuserConfirmation = "Y";
                                            SnowCollegeLibrary.CDList.Add(NewCDItem.CallNumber, NewCDItem);

                                            SnowCollegeLibrary.SaveBooks();
                                            SnowCollegeLibrary.SaveCDs();
                                            SnowCollegeLibrary.SaveOversizedBooks();

                                            Console.WriteLine("item Saved");
                                            Console.WriteLine("Press enter to continue");
                                            Console.ReadLine();
                                            AskingForType = false;
                                            break;

                                        }
                                        if (CDuserConfirmation == "R")
                                        {
                                            CDuserConfirmation = "R";
                                            AskingForType = false;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Not a valid option.  Enter 'Y' to confirm item details, 'R' to exit and not save item details :");
                                            OVuserConfirmation = Console.ReadLine();
                                        }
                                    }
                                    AskingForType = false;
                                    break;

                                default:
                                    Console.WriteLine("Invalid option.  Press Enter to try again.");
                                    Console.ReadLine();
                                    AskingForType = false;
                                    break;
                            }
                        }
                    }

                    if (UserInput == 5)
                    {
                        Console.WriteLine("Enter Patrons First Name: ");
                        string FName = Console.ReadLine();
                        Console.WriteLine("Enter Patrons Last Name: ");
                        string LName = Console.ReadLine();
                        Console.WriteLine("Enter Patrons ID");
                        int PatronID = Convert.ToInt32(Console.ReadLine());

                        Account newAccount = new Account(FName, LName, PatronID);
                        SnowCollegeLibrary.AccountList.Add(PatronID, newAccount);
                        accountStorage.SaveAccounts(SnowCollegeLibrary.AccountList);

                        Console.WriteLine("New Patron Added: " + newAccount.GetAccountDetails());

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    //not working if I enter something wrong  Not working even if I enter the correct thing
                    if (UserInput == 6)
                    {
                        Console.WriteLine("Enter in Call Number or Title");
                        string RequestedItem = Console.ReadLine();
                        
                        try
                        {
                            var item = SnowCollegeLibrary.SearchLibraryItems(RequestedItem);
                            Console.WriteLine(item.GetDetails());
                        }
                        catch
                        {
                            Console.WriteLine("Item not found.  Try again.");
                        }


                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == 7)
                    {
                        //SnowCollegeLibrary.DisplayLibraryItems(SnowCollegeLibrary.LibraryItemList);
                        SnowCollegeLibrary.LoadBooks();
                        foreach (var item in SnowCollegeLibrary.BookList)
                        {
                            Console.WriteLine(item.Value.GetDetails());
                        }

                        SnowCollegeLibrary.LoadOVBooks();
                        foreach (var item in SnowCollegeLibrary.OversizedBookList)
                        {
                            Console.WriteLine(item.Value.GetDetails());
                        }

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == 8)
                    {
                        SnowCollegeLibrary.DisplayPatrons();

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
