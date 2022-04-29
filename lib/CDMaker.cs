using MyLibrary.lib;

public class CDMaker
{
    public static CD CDMakerForLibrary(string CDTitle, string CDAuthor, Int64 CDBarcode, string CDCallNumber)
    {

        CD NewCDItem = new CD();
        NewCDItem.Title = CDTitle;
        NewCDItem.Artist = CDAuthor;
        NewCDItem.Barcode = CDBarcode;
        NewCDItem.CallNumber = CDCallNumber;
        NewCDItem.Availability = ItemAvailability.CheckedIn;

        return NewCDItem;

    }
}