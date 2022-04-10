using System;
namespace MyLibrary.lib;
public class Book : ICheckoutable
{
    public string CallNumber { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public string Barcode { get; set; }
    public string Author { get; set; }
    public DateTime DueDate { get; set; }
    public ItemType Type = ItemType.Book;
    public ItemAvailability Availability { get; set; }
    public ItemAvailability availability = ItemAvailability.CheckedIn;
    public Book(string _CallNumber, string _Title, string _ISBN, string _Author, string _Barcode)
    {
        this.CallNumber = _CallNumber;
        this.Title = _Title;
        this.ISBN = _ISBN;
        this.Author = _Author;
        this.Barcode = _Barcode;
    }

    public string CheckOut(ICheckoutable item, Account account)
    {
        var bookitem = (Book)item;
        bookitem.Availability = ItemAvailability.CheckedOut;
        account.holdList.Add(bookitem);
        var DueDate = DateTime.Today.AddDays(21);
        return ("Item successfully checked out to: " + account.FirstName + " " + account.LastName + " and is due on " + DueDate);
    }

    public string CheckIn(ICheckoutable item, Account account)
    {
        var bookitem = (Book)item;
        account.holdList.Remove(bookitem);
        bookitem.Availability = ItemAvailability.CheckedIn;
        return ("Item successfully checked in.");
    }

    public string Renew(ICheckoutable item)
    {
        var bookitem = (Book)item;
        this.DueDate = DateTime.Today.AddDays(21);
        return ("Item successfully renewed. Now due on: " + DueDate);
    }

    public string GetDetails()
    {
        return $"\n \n CallNumber: {CallNumber} \n Title: {Title} \n Author: {Author} \n ISBN: {ISBN} \n Item Type: {Type} \n Barcode: {Barcode} \n Availabilty: {Availability}";
    }

    public async void WriteToFile(ICheckoutable item)
    {
        using StreamWriter file = new("data.txt", append: true);
        await file.WriteLineAsync(item.GetDetails());
    }

}
