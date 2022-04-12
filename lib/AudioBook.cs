namespace MyLibrary.lib;

public abstract class AudioBook : Book
{
    public AudioBook(string _CallNumber, string _Title, Int64 _ISBN, string _Author, Int64 _Barcode) : base(_CallNumber, _Title, _ISBN, _Author, _Barcode)
    {

    }
    public string CheckOut(ILibraryItem item, Account account, List<ILibraryItem> holdList)
    {
        var bookitem = (AudioBook)item;
        bookitem.Availability = ItemAvailability.CheckedOut;
        DateTime today = DateTime.Today;
        var DueDate = today;
        return ("Item successfully checked out to: " + account.FirstName + " " + account.LastName);
    }
    public string CheckIn(ILibraryItem item)
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
