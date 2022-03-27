using System;
using System.Collections.Generic;

namespace MyLibrary
{
    internal partial class Program
    {
        public class NoInputGivenException : Exception
        {
            public NoInputGivenException(string message)
            {
                throw new NoInputGivenException(message);
            }
        }
        public enum ItemType
        {
            Book,       //title, author, publication date
            CD,         //title, artist, run time
            Magazine,   //publication/ journal, Issue, publication date
            DVD,        //title, director, release date, run time, 
            AudioBook,  //title, author, narrator, publication date, recording date?
            Childrens   //title, author, publication date
        }
        public enum ItemAvailability
        {
            CheckedIn,          //available for check out or can be placed on hold, not assigned to any patron
            CheckedOut,         //checked out and assigned to a patron, unavailable to other patrons
            OnHold,             //unavailable for check out, being held for a patron
            LostorStolen,       //marked as lost or stolen after a certain period of being overdue or checked out
            Pending,            // bought but not available yet, being repaired by library
            Unavailable = LostorStolen | CheckedOut | Pending,   //unavailable for checkout, but could fullfill these categories
        }

        public interface ICheckoutable
        {
            public string CheckOut(ICheckoutable item, Account account, int[] holdList);
            public string CheckIn(ICheckoutable item);
            //public DateTime DueDate{get; set;}
        }
        public interface IAppendable
        {

        }
        static void Main(string[] args)
        {
            Dictionary<string, Object> LibraryItemList = new Dictionary<string, Object>();

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
                6. DisplayLibraryItems -- unavailable
                7. DisplayPatrons -- unavailable
                8. Exit -- Exits program
                ");

            var UserInput = Console.ReadLine();
            while (UserInput != "Exit")
            {
                if (UserInput == "CheckOut")
                {
                    Console.WriteLine("Enter Item CallNumber to check out: ");
                    string userInputBook = (Console.ReadLine());
                    try
                    {
                        Console.WriteLine("Enter Account Id: ");
                        var userInput = Convert.ToInt32(Console.ReadLine());
                        if (userInput == 0)
                        {
                            throw new NoInputGivenException("no input given");
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
                        throw new NoInputGivenException("no input given");
                    }
                }
                if (UserInput == "CheckIn")
                {
                    Console.WriteLine("Enter Item CallNumber to check out: ");
                    string RequestedCallNumber = Console.ReadLine();
                    var requestedBook = (ICheckoutable)LibraryItemList[RequestedCallNumber];
                    Console.WriteLine(requestedBook.CheckIn(requestedBook));
                }
                if (UserInput == "AddLibraryItem")
                {
                    Console.WriteLine("Select Library Type:");
                    Console.WriteLine(@"
                Book
                CD");
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
            }
        }
    }
}
