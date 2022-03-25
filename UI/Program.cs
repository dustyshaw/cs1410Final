using System;
using System.Collections.Generic;

namespace MyLibrary
{
    internal partial class Program
    {
        public interface IAccount
        {
            string CheckOut();
            string CheckIn();
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
            // Available = CheckedIn
        }

        public interface ICheckoutable
        {

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
        }

        public class CD : ICheckoutable
        {
            private int iSBN;
            public int ISBN
            {
                get { return iSBN; }
                set { iSBN = value; }
            }
            private string title;
            public string Title
            {
                get { return title; }
                set { title = value; }
            }
            private string artist;
            public string Artist
            {
                get { return artist; }
                set { artist = value; }
            }
            public CD(int _ISBN, string _title, string _artist)
            {
                this.ISBN = _ISBN;
                this.Title = _title;
                this.Artist = _artist;
            }
        }
        public class Account
        {
            private string firstName;
            public string FirstName
            {
                get { return firstName; }
                set { firstName = value; }
            }
            private string lastName;
            public string LastName
            {
                get { return lastName; }
                set { lastName = value; }
            }
            private int id;
            public int ID
            {
                get { return id; }
                set { id = value; }
            }
            public static int numOfHoldsDefault = 0;
            public int[] holdList = new int[numOfHoldsDefault];
        }
        public static string CheckOut(ICheckoutable item, Account account, int[] holdList)
        {
            var bookitem = (Book)item;
            bookitem.availability = ItemAvailability.CheckedOut;
            return ("Item successfully checked out to: " + account.FirstName + " " + account.LastName);
        }
        public static string CheckIn(ICheckoutable item, Account account, int[] holdList)
        {
            var bookitem = (Book)item;
            bookitem.availability = ItemAvailability.CheckedIn;
            return ("Item successfully checked in.");
        }
        static void Main(string[] args)
        {
            // example of adding a library item
            Dictionary<int, Object> LibraryItemList = new Dictionary<int, Object>();
            Book newBook = new Book(12345, "Gone With the Wind", "Margaret Mitchell");
            LibraryItemList.Add(12345, newBook);

            // example of adding an account
            Dictionary<int, Account> AccountList = new Dictionary<int, Account>();
            Account newAct = new Account();
            newAct.FirstName = "Dusty";
            newAct.LastName = "Shaw";
            newAct.ID = 2301237;
            AccountList.Add(newAct.ID, newAct);

            Console.WriteLine("Enter in one of the following commands:");
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
                if (userInputBook == 0)
                {
                    throw new Exception();
                }
                else
                {
                    Console.WriteLine("Enter Account Id: ");
                    var userInput = Convert.ToInt32(Console.ReadLine());
                    if (userInput == 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        var requestedAccount = AccountList[userInput];
                        var requestedBook = LibraryItemList[userInputBook];
                        
                        Console.WriteLine(CheckOut((ICheckoutable)requestedBook, requestedAccount, requestedAccount.holdList));
                    }
                }
            }


            // example of adding a different type of library item
            CD newCD = new CD(12346, "Gone With The Wind Soundtrack", "Jim John");
            LibraryItemList.Add(12346, newCD);
            // part of a 'display all library items' list maybe
            // Console.WriteLine("Item Count: " + LibraryItemList.Count);

            // Console.WriteLine(CheckOut(newBook, newAct, newAct.holdList));
            // Console.WriteLine(newBook.Title + " by " + newBook.Author + " availability: " + newBook.availability);

            // Console.WriteLine(CheckIn(newBook, newAct, newAct.holdList));
            // Console.WriteLine(newBook.Title + " by " + newBook.Author + " availability: " + newBook.availability);

        }
    }
}
