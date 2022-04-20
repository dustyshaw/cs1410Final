namespace MyLibrary.lib;

public class OversizedBook : Book
{
    ItemType OVType = ItemType.OversizedBook;
    public ItemAvailability OVAvailability { get; set; }
    public ItemAvailability OVavailability = ItemAvailability.CheckedIn;
    public OversizedBook(string _CallNumber, string _Title, long _ISBN, string _Author, long _Barcode) : base(_CallNumber, _Title, _ISBN, _Author, _Barcode)
    {
    }
    public string GetDetails()
    {
        return $"\n \n Item Type: {Type} \n CallNumber: {CallNumber} \n Title: {Title} \n Author: {Author} \n ISBN: {ISBN} \n Barcode: {Barcode} \n Availabilty: {Availability}";
    }
}
