namespace MyLibrary.lib;
public class Book : ILibraryItem
{
    public string CallNumber { get; set; }
    public string Title { get; set; }
    public Int64 ISBN { get; set; }
    public Int64 Barcode { get; set; }
    public string Author { get; set; }
    public DateTime DueDate { get; set; }
    public ItemAvailability Availability { get; set; }
    public ItemAvailability availability = ItemAvailability.CheckedIn;

    public Book()
    {
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
        return $"\n \n Item Type: {GetItemType()} \n CallNumber: {CallNumber} \n Title: {Title} \n Author: {Author} \n ISBN: {ISBN} \n Barcode: {Barcode} \n Availabilty: {Availability}";
    }

    public async void WriteToTextFile(ILibraryItem item)
    {
        using StreamWriter file = new("data.txt", append: true);
        await file.WriteLineAsync(item.GetDetails());
    }

    public ItemType GetItemType()
    {
        return ItemType.Book;
    }

}
