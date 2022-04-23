namespace MyLibrary.lib;

public class OversizedBook : Book
{
    public ItemAvailability OVAvailability { get; set; }
    public ItemAvailability OVavailability = ItemAvailability.CheckedIn;
    public OversizedBook() : base()
    {
    }
    public string GetDetails()
    {
        return $"\n \n Item Type: {GetItemType()} \n CallNumber: {CallNumber} \n Title: {Title} \n Author: {Author} \n ISBN: {ISBN} \n Barcode: {Barcode} \n Availabilty: {Availability}";
    }
    public ItemType GetItemType()
    {
        return ItemType.OversizedBook;
    }
}
