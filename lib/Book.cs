namespace MyLibrary.lib;
public class Book : ICheckoutable
{
    public string CallNumber { get; set; }
    public string Title { get; set; }
    public int ISBN { get; set; }
    public string Author { get; set; }
    public ItemType Type = ItemType.Book;
    public ItemAvailability Availability { get; set; }
    public ItemAvailability availability = ItemAvailability.CheckedIn;
    public Book(string _CallNumber, string _Title, int _ISBN, string _Author)
    {
        this.CallNumber = _CallNumber;
        this.Title = _Title;
        this.ISBN = _ISBN;
        this.Author = _Author;
    }
    public string CheckOut(ICheckoutable item, Account account, int[] holdList)
    {
        var bookitem = (Book)item;
        bookitem.Availability = ItemAvailability.CheckedOut;
        DateTime today = DateTime.Today;
        var DueDate = today;
        return ("Item successfully checked out to: " + account.FirstName + " " + account.LastName);
    }
    public string CheckIn(ICheckoutable item)
    {
        var bookitem = (Book)item;
        bookitem.Availability = ItemAvailability.CheckedIn;
        return ("Item successfully checked in.");
    }
    public string GetDetails()
    {
        return $"\n \n CallNumber: {CallNumber} Title: {Title} \n Author: {Author} \n ISBN: {ISBN} \n Item Type: {Type} \n Availabilty: {Availability}";
    }
}

public abstract class AudioBook : Book
{
    public AudioBook(string _CallNumber, string _Title, int _ISBN, string _Author) : base(_CallNumber, _Title, _ISBN, _Author)
    {

    }
    public string CheckOut(ICheckoutable item, Account account, int[] holdList)
    {
        var bookitem = (AudioBook)item;
        bookitem.Availability = ItemAvailability.CheckedOut;
        DateTime today = DateTime.Today;
        var DueDate = today;
        return ("Item successfully checked out to: " + account.FirstName + " " + account.LastName);
    }
    public string CheckIn(ICheckoutable item)
    {
        var bookitem = (Book)item;
        bookitem.Availability = ItemAvailability.CheckedIn;
        return ("Item successfully checked in.");
    }
    public virtual string GetDetails()
    {
        return $"\n \n CallNumber: {CallNumber} Title: {Title} \n Author: {Author} \n ISBN: {ISBN} \n Item Type: {Type} \n Availabilty: {Availability}";
    }
}
public class EAudioBook : AudioBook
{
    public decimal RunTime;
    public EAudioBook(string _CallNumber, string _Title, int _ISBN, string _Author, decimal _RunTime) : base(_CallNumber, _Title, _ISBN, _Author)
    {
        this.RunTime = _RunTime;
    }
    public override string GetDetails()
    {
        return $"\n \n CallNumber: {CallNumber} Title: {Title} \n Author: {Author} \n ISBN: {ISBN} \n Item Type: {Type} \n Availabilty: {Availability} \n RunTime: {RunTime}";
    }
}
