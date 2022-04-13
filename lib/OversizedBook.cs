namespace MyLibrary.lib;

public class OversizedBook : Book
{
    ItemType Type = ItemType.OversizedBook;
    public ItemAvailability Availability { get; set; }
    public ItemAvailability availability = ItemAvailability.CheckedIn;
    public OversizedBook(string _CallNumber, string _Title, long _ISBN, string _Author, long _Barcode) : base(_CallNumber, _Title, _ISBN, _Author, _Barcode)
    {
    }

}
