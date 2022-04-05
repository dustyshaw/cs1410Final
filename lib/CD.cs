namespace MyLibrary.lib;

public class CD : ICheckoutable
{
    public string CallNumber { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public ItemAvailability Availability { get; set; }
    public ItemType type = ItemType.Book;
    public CD(string _CallNumber, string _title, string _artist)
    {
        this.CallNumber = _CallNumber;
        this.Title = _title;
        this.Artist = _artist;
    }
    public string CheckOut(ICheckoutable item, Account account, int[] holdList)
    {
        var bookitem = (CD)item;
        bookitem.Availability = ItemAvailability.CheckedOut;

        return ("Item successfully checked out to: " + account.FirstName + " " + account.LastName + ".");
    }
    public string CheckIn(ICheckoutable item)
    {
        var bookitem = (CD)item;
        bookitem.Availability = ItemAvailability.CheckedIn;
        return ("Item successfully checked in.");
    }
    public string GetDetails()
    {
        return $"\n CallNumber: {CallNumber} \n Title: {Title} \n Author: {Artist} \n Availability: {this.Availability} \n";
    }
}