using System;
namespace MyLibrary.lib;
public class Book : ILibraryItem
{
    public string CallNumber { get; set; }
    public string Title { get; set; }
    public Int64 ISBN { get; set; }
    public Int64 Barcode { get; set; }
    public string Author { get; set; }
    public DateTime DueDate { get; set; }
    public ItemType Type = ItemType.Book;
    public ItemAvailability Availability { get; set; }
    public ItemAvailability availability = ItemAvailability.CheckedIn;

    public Book(string _CallNumber, string _Title, Int64 _ISBN, string _Author, Int64 _Barcode)
    {
        this.CallNumber = _CallNumber;
        this.Title = _Title;
        this.ISBN = _ISBN;
        this.Author = _Author;
        this.Barcode = _Barcode;
    }

    public string CheckOut(ILibraryItem item, Account account)
    {
        var bookitem = (Book)item;
        bookitem.Availability = ItemAvailability.CheckedOut;
        account.holdList.Add(bookitem);
        var DueDate = DateTime.Today.AddDays(21);
        return ("Item successfully checked out to: " + account.FirstName + " " + account.LastName + " and is due on " + DueDate);
    }

    public string CheckIn(ILibraryItem item, Account account)
    {
        var bookitem = (Book)item;
        account.holdList.Remove(bookitem);
        bookitem.Availability = ItemAvailability.CheckedIn;
        return ("Item successfully checked in.");
    }

    public string Renew(ILibraryItem item)
    {
        var bookitem = (Book)item;
        this.DueDate = DateTime.Today.AddDays(21);
        return ("Item successfully renewed. Now due on: " + DueDate);
    }

    public string GetDetails()
    {
        return $"\n \n CallNumber: {CallNumber} \n Title: {Title} \n Author: {Author} \n ISBN: {ISBN} \n Item Type: {Type} \n Barcode: {Barcode} \n Availabilty: {Availability}";
    }

    public async void WriteToFile(ILibraryItem item)
    {
        using StreamWriter file = new("data.txt", append: true);
        await file.WriteLineAsync(item.GetDetails());
    }

    public static Int64 ParseISBN (string input)
    {
        if(input == null)
        {
            throw new ArgumentNullException();
        }
        if(input.Length != 10 && input.Length != 13)
        {
            throw new ArgumentOutOfRangeException();
        }
        return Int64.Parse(input);
    }

}
