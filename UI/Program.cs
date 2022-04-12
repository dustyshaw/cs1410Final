using System;
using System.Collections.Generic;
using MyLibrary.lib;

namespace MyLibrary
{
    internal partial class Program
    {

        static void Main(string[] args)
        {
            OversizedBook ovBook = new OversizedBook("989.a1", "Title", 144444444444, "Author Name", 999999999909);

            //all logic needs to be moved
            AccountJsonFileStorageService storage = new AccountJsonFileStorageService();

            Library SnowCollegeLibrary = new Library(storage);
            Dictionary<string, ILibraryItem> LibraryItemList = new Dictionary<string, ILibraryItem>(); //move to lib.library 

            Book newBook = new Book("123.abc", "Wonder", 123456789, "Lewis Carol", 34230000109820);
            LibraryItemList.Add(newBook.CallNumber, newBook);

            Dictionary<int, Account> AccountList = new Dictionary<int, Account>();
            Account newAct = new Account("Dusty", "Shaw", 123);
            AccountList.Add(newAct.ID, newAct);

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
                        Console.WriteLine("Enter Account Id: ");
                        var userInputID = Convert.ToInt32(Console.ReadLine());

                        var requestedAccount = AccountList[userInputID];  //grabs account from list
                        var RequestedItem = (ILibraryItem)LibraryItemList[userInputBook];  //converts item to icheckoutable and grabs item from libraryItem list
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
                        var requestedAccount = AccountList[userInputID];  //grabs account
                        var RequestedItem = (ILibraryItem)LibraryItemList[RequestedCallNumber];  //grabs item from list
                        Console.WriteLine(RequestedItem.CheckIn(RequestedItem, requestedAccount));      //checks it in using ILibraryItem check in method

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "Renew")
                    {
                        Console.WriteLine("Enter Item CallNumber to renew: ");
                        string RequestedCallNumber = Console.ReadLine();
                        var RequestedItem = (ILibraryItem)LibraryItemList[RequestedCallNumber];
                        Console.WriteLine(RequestedItem.Renew(RequestedItem));

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "AddLibraryItem")
                    {
                        Console.WriteLine("Select Item Type:");
                        Console.WriteLine("\nBook \nCD");
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
                                            Console.WriteLine("invalid ISBN.  Must be 10 or 13 characters.");
                                        }
                                    }
                                    Console.WriteLine("Enter Barcode");
                                    Int64 Barcode = Convert.ToInt64(Console.ReadLine());

                                    //logic
                                    Book NewBookItem = new Book(CallNumber, Title, ISBN, Author, Barcode);
                                    LibraryItemList.Add(CallNumber, NewBookItem);
                                    NewBookItem.WriteToFile(NewBookItem);
                                    Console.WriteLine($" \n One {NewBookItem.Type} added: " + NewBookItem.GetDetails());

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
                                    LibraryItemList.Add(CDCallNumber, NewCDItem);
                                    Console.WriteLine($" \n one {NewCDItem.Type} added: " + NewCDItem.GetDetails());

                                    Console.WriteLine("Press Enter to continue");
                                    Console.ReadLine();
                                    AskingForType = false;
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

                        //logic
                        Account newAccount = new Account(FName, LName, PatronID);
                        AccountList.Add(PatronID, newAccount);

                        Console.WriteLine("New Patron Added: " + newAccount.GetAccountDetails());

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "SearchLibraryItems")
                    {
                        Console.WriteLine("Enter in Call Number or Title");
                        string RequestedItem = Console.ReadLine();

                        Library.SearchLibraryItems(RequestedItem, LibraryItemList);

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "DisplayLibraryItems")
                    {
                        Library.DisplayLibraryItems(LibraryItemList);

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "DisplayPatrons")
                    {
                        Library.DisplayPatrons(AccountList);

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
