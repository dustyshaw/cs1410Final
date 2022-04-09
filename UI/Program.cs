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

            Book newBook = new Book("123.abc", "Wonder", "123456789", "Lewis Carol", "34230000109820");
            LibraryItemList.Add(newBook.CallNumber, newBook);

            // example of adding an account
            Dictionary<int, Account> AccountList = new Dictionary<int, Account>();
            Account newAct = new Account("Dusty", "Shaw", 123);
            AccountList.Add(newAct.ID, newAct);

            // Create a string array with the lines of text
            string[] lines = { newBook.GetDetails() };

            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }


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
                5. AddNewPatron -- unavailable
                6. SearchLibraryItems 
                7. DisplayLibraryItems -- unavailable
                8. DisplayPatrons -- unavailable
                9. Exit -- Exits program
                ");

                var UserInput = Console.ReadLine();
                if (UserInput != "Exit")
                {

                    if (UserInput == "CheckOut")
                    {
                        Console.WriteLine("Enter Item CallNumber to check out: ");
                        string userInputBook = (Console.ReadLine());
                        try
                        {
                            Console.WriteLine("Enter Account Id: ");
                            var userInput = Convert.ToInt32(Console.ReadLine());
                            if (userInput < 0)
                            {
                                throw new ArgumentNullException();

                            }
                            else
                            {
                                var requestedAccount = AccountList[userInput];
                                var requestedBook = (ICheckoutable)LibraryItemList[userInputBook];
                                Console.WriteLine(requestedBook.CheckOut(requestedBook, requestedAccount));
                            }
                        }
                        catch
                        {
                            throw new ArgumentNullException();
                        }
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "CheckIn")
                    {
                        Console.WriteLine("Enter Item CallNumber to check out: ");
                        string RequestedCallNumber = Console.ReadLine();
                        var RequestedItem = (ICheckoutable)LibraryItemList[RequestedCallNumber];
                        Console.WriteLine(RequestedItem.CheckIn(RequestedItem));
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "Renew")
                    {
                        Console.WriteLine("Enter Item CallNumber to renew: ");
                        string RequestedCallNumber = Console.ReadLine();
                        var RequestedItem = (ICheckoutable)LibraryItemList[RequestedCallNumber];
                        Console.WriteLine(RequestedItem.Renew(RequestedItem));
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "AddLibraryItem")
                    {
                        Console.WriteLine("Select Library Type:");
                        Console.WriteLine("\nBook \nCD");
                        string BookType = Console.ReadLine();
                        bool AskingForType = true;
                        while (AskingForType == true)
                        {
                            switch (BookType)
                            {
                                case "Book":
                                    Console.WriteLine("Enter Item CallNumber.  This is usually found in the front cover of your book (ex. 578.3S)");
                                    string CallNumber = Console.ReadLine();
                                    Console.WriteLine("Enter Item Title");
                                    string Title = Console.ReadLine();
                                    Console.WriteLine("Enter ISBN");
                                    string ISBN = Console.ReadLine();
                                    Console.WriteLine("Enter Authors Full Name");
                                    string Author = Console.ReadLine();
                                    Console.WriteLine("Enter Barcode");
                                    string Barcode = Console.ReadLine();

                                    Book NewBookItem = new Book(CallNumber, Title, ISBN, Author, Barcode);
                                    LibraryItemList.Add(CallNumber, NewBookItem);
                                    Console.WriteLine($" \n one {NewBookItem.Type} added: " + NewBookItem.GetDetails());

                                    Console.WriteLine("Press Enter to continue");
                                    Console.ReadLine();
                                    AskingForType = false;
                                    break;

                                case "CD":
                                    Console.WriteLine("Enter Item CallNumber.  This is usually found in the front cover of your book (ex. 578.3S)");
                                    string CDCallNumber = Console.ReadLine();
                                    Console.WriteLine("Enter Item Title");
                                    string CDTitle = Console.ReadLine();
                                    Console.WriteLine("Enter Artist Name");
                                    string CDAuthor = Console.ReadLine();

                                    CD NewCDItem = new CD(CDCallNumber, CDTitle, CDAuthor);
                                    LibraryItemList.Add(CDCallNumber, NewCDItem);
                                    Console.WriteLine($" \n one {NewCDItem.Type} added: " + NewCDItem.GetDetails());

                                    Console.WriteLine("Press Enter to continue");
                                    Console.ReadLine();
                                    AskingForType = false;
                                    break;
                            }
                        }
                    }

                    if (UserInput == "SearchLibraryItems")
                    {
                        Console.WriteLine("Enter in Call Number or Title");
                        string RequestedItem = Console.ReadLine();

                        foreach (KeyValuePair<string, ICheckoutable> item in LibraryItemList)
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

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }

                    if (UserInput == "DisplayLibraryItems")
                    {
                        foreach (KeyValuePair<string, ICheckoutable> item in LibraryItemList)
                        {
                            Console.WriteLine(item.Value.GetDetails());
                        }
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
