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
            public string CheckIn(ICheckoutable item, Account account, int[] holdList);
        }
        public class Book : ICheckoutable
        {
            public int ISBN { get; set; }
            public string Title { get; set; }
            private string Author { get; set; }
            public ItemType type = ItemType.Book;
            public ItemAvailability Availability { get; set; }
            public ItemAvailability availability = ItemAvailability.CheckedIn;
            public Book(int _ISBN, string _title, string _author)
            {
                this.ISBN = _ISBN;
                this.Title = _title;
                this.Author = _author;
            }
            public string CheckOut(ICheckoutable item, Account account, int[] holdList)
            {
                var bookitem = (Book)item;
                bookitem.Availability = ItemAvailability.CheckedOut;
                return ("Item successfully checked out to: " + account.FirstName + " " + account.LastName);
            }
            public string CheckIn(ICheckoutable item, Account account, int[] holdList)
            {
                var bookitem = (Book)item;
                bookitem.Availability = ItemAvailability.CheckedIn;
                return ("Item successfully checked in.");
            }
        }

        public class CD : ICheckoutable
        {
            private int ISBN { get; set; }
            private string Title { get; set; }
            private string Artist { get; set; }
            public ItemAvailability Availability { get; set; }
            public ItemType type = ItemType.Book;
            public CD(int _ISBN, string _title, string _artist)
            {
                this.ISBN = _ISBN;
                this.Title = _title;
                this.Artist = _artist;
            }
            public string CheckOut(ICheckoutable item, Account account, int[] holdList)
            {
                var bookitem = (CD)item;
                bookitem.Availability = ItemAvailability.CheckedOut;
                return ("Item successfully checked out to: " + account.FirstName + " " + account.LastName);
            }
            public string CheckIn(ICheckoutable item, Account account, int[] holdList)
            {
                var bookitem = (CD)item;
                bookitem.Availability = ItemAvailability.CheckedIn;
                return ("Item successfully checked in.");
            }
        }

        public class Account
        {
            public Account(string _FirstName, string _LastName, int _ID)
            {
                this.FirstName = _FirstName;
                this.LastName = _LastName;
                this.ID = _ID;
            }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int ID { get; set; }
            public static int numOfHoldsDefault = 0;
            public int[] holdList = new int[numOfHoldsDefault];
        }
        static void Main(string[] args)
        {
            Dictionary<int, Object> LibraryItemList = new Dictionary<int, Object>();

            // example of adding a different type of library item
            CD newCD = new CD(12346, "Gone With The Wind Soundtrack", "Jim John");
            LibraryItemList.Add(12346, newCD);

            // example of adding a library item as a book
            Book newBook = new Book(12345, "Gone With the Wind", "Margaret Mitchell");
            LibraryItemList.Add(12345, newBook);

            // example of adding an account
            Dictionary<int, Account> AccountList = new Dictionary<int, Account>();
            Account newAct = new Account("Dusty", "Shaw", 123);
            AccountList.Add(newAct.ID, newAct);

            Console.WriteLine(@"Welcome to the Library App where library workers can keep track of library items,
            check out library items, renew them, and add library patrons.");
            Console.WriteLine("Enter in one of the following commands (ex. to check out a book, enter the word 'CheckOut'):");
            Console.WriteLine(@"
                1. CheckOut
                2. CheckIn -- unavailable
                3. Renew -- unavailable
                4. AddLibraryItem -- unavailable
                5. AddNewPatron -- unavailable
                6. DisplayLibraryItems -- unavailable
                7. DisplayPatrons -- unavailable
                ");

            var UserInput = Console.ReadLine();
            if (UserInput == "CheckOut")
            {
                Console.WriteLine("Enter Item id to check out: ");
                int userInputBook = Convert.ToInt32(Console.ReadLine());
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
                        var requestedBook = (Book)LibraryItemList[userInputBook];
                        Console.WriteLine(requestedBook.CheckOut((ICheckoutable)requestedBook, requestedAccount, requestedAccount.holdList));
                    }
                }
                catch
                {
                    throw new NoInputGivenException("no input given");
                }
            }
        }
    }
}
