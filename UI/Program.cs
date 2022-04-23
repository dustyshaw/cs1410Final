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

                        //Library takes care of saving all items
                        SnowCollegeLibrary.SaveBooks();
                        SnowCollegeLibrary.SaveCDs();
                        SnowCollegeLibrary.SaveOversizedBooks();

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "CheckIn")
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

                    if (UserInput == "Renew")
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
                                    var NewBookItem = BookMaker.BookMakerforLibrary(SnowCollegeLibrary);
                                    Console.Clear();
                                    Console.WriteLine(NewBookItem.GetDetails() + " \n Enter 'Y' to confirm item details, 'R' to exit and not save item details : ");
                                    var userConfirmation = Console.ReadLine();

                                    while (userConfirmation != "Y" || userConfirmation != "R")
                                    {
                                        if (userConfirmation == "Y")
                                        {
                                            userConfirmation = "Y";

                                            //New book is added to lists and then saved to a file by SnowCollegeLibrary
                                            SnowCollegeLibrary.LibraryItemList.Add(NewBookItem.CallNumber, NewBookItem);
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

                                case "OversizedBook":

                                    // "OversizedBookMaker" makes the book for whatever library is passed in. 
                                    var OVNewBookItem = OversizedBookMaker.OversizedBookMakerForLibrary(SnowCollegeLibrary);
                                    Console.Clear();

                                    Console.WriteLine(OVNewBookItem.GetDetails() + $"Enter 'Y' to confirm item details, 'R' to exit and not save item details : ");
                                    var OVuserConfirmation = Console.ReadLine();

                                    while (OVuserConfirmation != "Y" || OVuserConfirmation != "R")
                                    {
                                        if (OVuserConfirmation == "Y")
                                        {
                                            OVuserConfirmation = "Y";
                                            //var casted = (ILibraryItem)OVNewBookItem;

                                            SnowCollegeLibrary.LibraryItemList.Add(OVNewBookItem.CallNumber, OVNewBookItem);
                                            //itemStorage.SaveItems(SnowCollegeLibrary.LibraryItemList);

                                            //Library.OversizedBookList.Add(OVNewBookItem.CallNumber, OVNewBookItem);
                                            //Library.SaveAllItems(CDStorage, bookStorage, OVbookStorage);

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

                                case "CD":
                                    CD NewCDItem = CDMaker.CDMakerForLibrary(SnowCollegeLibrary);
                                    Console.Clear();

                                    Console.WriteLine(NewCDItem.GetDetails() + " \n Enter 'Y' to confirm item details, 'R' to exit and not save item details : ");
                                    var CDuserConfirmation = Console.ReadLine();

                                    while (CDuserConfirmation != "Y" && CDuserConfirmation != "R")
                                    {
                                        if (CDuserConfirmation == "Y")
                                        {

                                            CDuserConfirmation = "Y";
                                            SnowCollegeLibrary.LibraryItemList.Add(NewCDItem.CallNumber, NewCDItem);
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
                                    break;
                            }
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

                        Account newAccount = new Account(FName, LName, PatronID);
                        SnowCollegeLibrary.AccountList.Add(PatronID, newAccount);
                        accountStorage.SaveAccounts(SnowCollegeLibrary.AccountList);

                        Console.WriteLine("New Patron Added: " + newAccount.GetAccountDetails());

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    //not working if I enter something wrong
                    if (UserInput == "SearchLibraryItems")
                    {
                        //Console.WriteLine("Enter in Call Number or Title");
                        string RequestedItem;
                        while (true)
                        {
                            Console.WriteLine("Enter a call number or title:");
                            try
                            {
                                RequestedItem = ILibraryItem.ParseSearchRequest(Console.ReadLine(), SnowCollegeLibrary);
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Invalid input");
                            }
                        }
                        SnowCollegeLibrary.SearchLibraryItems(RequestedItem, SnowCollegeLibrary.LibraryItemList);

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "DisplayLibraryItems")
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

                    if (UserInput == "DisplayPatrons")
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
