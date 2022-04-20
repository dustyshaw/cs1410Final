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

            BookJsonFileStorageService bookStorage = new BookJsonFileStorageService();

            Library SnowCollegeLibrary = new Library(accountStorage);

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
                        Library.CheckOutItem(RequestedAccID, RequestedBookCallNumber);

                        itemStorage.SaveItems(Library.LibraryItemList);

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "CheckIn")
                    {
                        Console.WriteLine("Enter Item CallNumber to check in: ");
                        string RequestedCallNumber = Console.ReadLine();
                        Console.WriteLine("Enter Account Id: ");
                        int userInputID = Convert.ToInt32(Console.ReadLine());

                        Library.CheckInItem(RequestedCallNumber, userInputID);

                        itemStorage.SaveItems(Library.LibraryItemList);
                        bookStorage.SaveItems(Library.BookList);

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "Renew")
                    {
                        Console.WriteLine("Enter Item CallNumber to renew: ");
                        string RequestedCallNumber = Console.ReadLine();

                        Library.RenewItem(RequestedCallNumber);

                        itemStorage.SaveItems(Library.LibraryItemList);
                        bookStorage.SaveItems(Library.BookList);


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
                                    var NewBookItem = BookMaker.BookMakerforLibrary();
                                    Console.Clear();
                                    Console.WriteLine(NewBookItem.GetDetails() + " \n Enter 'Y' to confirm item details, 'R' to exit and not save item details : ");
                                    var userConfirmation = Console.ReadLine();

                                    while (userConfirmation != "Y" || userConfirmation != "R")
                                    {
                                        if (userConfirmation == "Y")
                                        {
                                            userConfirmation = "Y";
                                            // Library.LibraryItemList.Add(NewBookItem.CallNumber, NewBookItem);
                                            Library.BookList.Add(NewBookItem.CallNumber, NewBookItem);
                                            // itemStorage.SaveItems(Library.LibraryItemList);
                                            bookStorage.SaveItems(Library.BookList);

                                            Console.WriteLine("item Saved");
                                            Console.WriteLine("Press enter to continue");
                                            Console.ReadLine();
                                            AskingForType = false;
                                            break;
                                        }
                                        if (userConfirmation == "R")
                                        {
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
                                    var OVNewBookItem = OversizedBookMaker.OversizedBookMakerForLibrary();
                                    Console.Clear();

                                    Console.WriteLine(OVNewBookItem.GetDetails() + $"Enter 'Y' to confirm item details, 'R' to exit and not save item details : ");
                                    var OVuserConfirmation = Console.ReadLine();

                                    while (OVuserConfirmation != "Y" || OVuserConfirmation != "R")
                                    {
                                        if (OVuserConfirmation == "Y")
                                        {
                                            OVuserConfirmation = "Y";
                                            var casted = (ILibraryItem)OVNewBookItem;
                                            Library.LibraryItemList.Add(casted.CallNumber, casted);
                                            itemStorage.SaveItems(Library.LibraryItemList);
                                            bookStorage.SaveItems(Library.BookList);

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
                                    CD NewCDItem = CDMaker.CDMakerForLibrary();
                                    Console.Clear();

                                    Console.WriteLine(NewCDItem.GetDetails() + " \n Enter 'Y' to confirm item details, 'R' to exit and not save item details : ");
                                    var CDuserConfirmation = Console.ReadLine();

                                    while (CDuserConfirmation != "Y" && CDuserConfirmation != "R")
                                    {
                                        if (CDuserConfirmation == "Y")
                                        {
                                            CDuserConfirmation = "Y";
                                            var castedCD = (ILibraryItem)NewCDItem;
                                            Library.LibraryItemList.Add(castedCD.CallNumber, castedCD);
                                            itemStorage.SaveItems(Library.LibraryItemList);
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
                        Library.AccountList.Add(PatronID, newAccount);
                        accountStorage.SaveAccounts(Library.AccountList);

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
                        Library.DisplayLibraryItems(itemStorage.LoadItems());

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "DisplayPatrons")
                    {
                        Library.DisplayPatrons();
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
