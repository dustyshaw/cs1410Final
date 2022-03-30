using System;
using System.Collections.Generic;
using MyLibrary.lib;

namespace MyLibrary
{
    internal partial class Program
    {
        
        static void Main(string[] args)
        {
            Dictionary<string, ICheckoutable> LibraryItemList = new Dictionary<string, ICheckoutable>(); //move to lib.library 

            // example of adding an account
            Dictionary<int, Account> AccountList = new Dictionary<int, Account>();
            Account newAct = new Account("Dusty", "Shaw", 123);
            AccountList.Add(newAct.ID, newAct);

            Console.WriteLine(@"Welcome to the Library App where library workers can keep track of library items,
            check out library items, renew them, and add library patrons.");
            Console.WriteLine("Enter in one of the following commands (ex. to check out a book, enter the word 'CheckOut'):");
            Console.WriteLine(@"
                1. CheckOut
                2. CheckIn
                3. Renew -- unavailable
                4. AddLibraryItem 
                5. AddNewPatron -- unavailable
                6. SearchLibraryItems
                7. DisplayLibraryItems -- unavailable
                8. DisplayPatrons -- unavailable
                9. Exit -- Exits program
                ");

            var UserInput = Console.ReadLine();
            while (UserInput != "Exit")
            {
                if (UserInput == "CheckOut" || UserInput == "1")
                {
                    Console.WriteLine("Enter Item CallNumber to check out: ");
                    string userInputBook = (Console.ReadLine());
                    try
                    {
                        Console.WriteLine("Enter Account Id: ");
                        var userInput = Convert.ToInt32(Console.ReadLine());
                        if (userInput ==0)
                        {
                            throw new Exception("no input given");
                        }
                        else
                        {
                            var requestedAccount = AccountList[userInput];
                            var requestedBook = (ICheckoutable)LibraryItemList[userInputBook];
                            Console.WriteLine(requestedBook.CheckOut(requestedBook, requestedAccount, requestedAccount.holdList));
                        }
                    }
                    catch
                    {
                        throw new Exception("no input given");
                    }
                }
                if (UserInput == "CheckIn" || UserInput == "2")
                {
                    Console.WriteLine("Enter Item CallNumber to check out: ");
                    string RequestedCallNumber = Console.ReadLine();
                    var requestedBook = (ICheckoutable)LibraryItemList[RequestedCallNumber];
                    Console.WriteLine(requestedBook.CheckIn(requestedBook));
                }
                if (UserInput == "AddLibraryItem" || UserInput == "4")
                {
                    Console.WriteLine("Select Library Type:");
                    Console.WriteLine("\nBook \nCD");
                    string BookType = Console.ReadLine();
                    switch (BookType)
                    {
                        case "Book":
                            Console.WriteLine("Enter Item CallNumber.  This is usually found in the front cover of your book (ex. 578.3S)");
                            string CallNumber = Console.ReadLine();
                            Console.WriteLine("Enter Item Title");
                            string Title = Console.ReadLine();
                            Console.WriteLine("Enter ISBN");
                            int ISBN = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Author Name");
                            string Author = Console.ReadLine();
                            Book NewBookItem = new Book(CallNumber, Title, ISBN, Author);
                            LibraryItemList.Add(CallNumber, NewBookItem);
                            break;
                        case "CD":
                            Console.WriteLine("Enter Item CallNumber.  This is usually found in the front cover of your book (ex. 578.3S)");
                            string CDCallNumber = Console.ReadLine();
                            Console.WriteLine("Enter Item Title");
                            string CDTitle = Console.ReadLine();
                            Console.WriteLine("Enter Author Name");
                            string CDAuthor = Console.ReadLine();
                            CD NewCDItem = new CD(CDCallNumber, CDTitle, CDAuthor);
                            LibraryItemList.Add(CDCallNumber, NewCDItem);
                            break;
                    }
                }
                if (UserInput == "SearchLibraryItems" || UserInput == "6")
                {
                    
                }
            }
        }
    }
}
