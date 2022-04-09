namespace MyLibrary.lib;

public class CD : ICheckoutable
{
    public string CallNumber { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public DateTime DueDate { get; set; }
    public ItemAvailability Availability { get; set; }
    public ItemType Type = ItemType.CD;
    public CD(string _CallNumber, string _title, string _artist)
    {
        this.CallNumber = _CallNumber;
        this.Title = _title;
        this.Artist = _artist;
    }
    public string CheckOut(ICheckoutable item, Account account)
    {
        var bookitem = (CD)item;
        bookitem.Availability = ItemAvailability.CheckedOut;

        return ("Item successfully checked out to: " + account.FirstName + " " + account.LastName + ".");
    }
    public string CheckIn(ICheckoutable item, Account account)
    {
        var bookitem = (CD)item;
        bookitem.Availability = ItemAvailability.CheckedIn;
        return ("Item successfully checked in.");
    }
    public string Renew(ICheckoutable item)
    {
        var bookitem = (CD)item;
        this.DueDate = DateTime.Today.AddDays(21);
        return ("Item successfully renewed. Now due on: " + DueDate);
    }
    public string GetDetails()
    {
        return $"\n CallNumber: {CallNumber} \n Title: {Title} \n Author: {Artist} \n Availability: {this.Availability} \n";
    }
}