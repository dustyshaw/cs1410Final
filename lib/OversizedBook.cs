namespace MyLibrary.lib;

public class OversizedBook : Book
{
    ItemType OVType = ItemType.OversizedBook;
    public ItemAvailability OVAvailability { get; set; }
    public ItemAvailability OVavailability = ItemAvailability.CheckedIn;
    public OversizedBook(string _CallNumber, string _Title, long _ISBN, string _Author, long _Barcode) : base(_CallNumber, _Title, _ISBN, _Author, _Barcode)
    {
    }

}
