using MyLibrary.lib;

public class OversizedBookMaker
{
    public static OversizedBook OversizedBookMakerForLibrary(Library SnowCollegeLibrary)
    {
        string OVCallNumber;
        while (true)
        {
            Console.WriteLine("Enter Item CallNumber.  This is usually found in the front cover of your book (ex. 578.3S)");
            try
            {
                OVCallNumber = ILibraryItem.ParseCallNumbers(Console.ReadLine(), SnowCollegeLibrary);
                break;
            }
            catch
            {
                Console.WriteLine("Invalid CallNumber");
            }
        }

        Console.WriteLine("Enter Item Title");
        string OVTitle = Console.ReadLine();
        Console.WriteLine("Enter Authors Full Name");
        string OVAuthor = Console.ReadLine();

        Int64 OVISBN;
        while (true)
        {
            Console.WriteLine("Enter ISBN");
            try
            {
                OVISBN = ILibraryItem.ParseISBN(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("invalid ISBN.  Must be 10 or 13 characters.");
            }
        }

        Int64 OVBarcode;
        while (true)
        {
            Console.WriteLine("Enter Barcode");
            try
            {
                OVBarcode = ILibraryItem.ParseBarcodes(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("invalid Barcode.  Must be 12 digits.");
            }
        }
        // OversizedBook OVNewBookItem = new OversizedBook(OVCallNumber, OVTitle, OVISBN, OVAuthor, OVBarcode);
        OversizedBook OVNewBookItem = new OversizedBook();
        OVNewBookItem.Author = OVAuthor;
        OVNewBookItem.Title = OVTitle;
        OVNewBookItem.Barcode = OVBarcode;
        OVNewBookItem.CallNumber = OVCallNumber;
        OVNewBookItem.Availability = ItemAvailability.CheckedIn;
        return OVNewBookItem;
    }
}
