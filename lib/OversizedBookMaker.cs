using MyLibrary.lib;

public class OversizedBookMaker
{
    public static OversizedBook OversizedBookMakerForLibrary()
    {
        string OVCallNumber;
        while (true)
        {
            Console.WriteLine("Enter Item CallNumber.  This is usually found in the front cover of your book (ex. 578.3S)");
            try
            {
                OVCallNumber = ILibraryItem.ParseCallNumbers(Console.ReadLine());
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
        OversizedBook OVNewBookItem = new OversizedBook(OVCallNumber, OVTitle, OVISBN, OVAuthor, OVBarcode);
        return OVNewBookItem;
    }
}

public class CDMaker
{
    public static CD CDMakerForLibrary()
    {
        string CDCallNumber;
        while (true)
        {
            Console.WriteLine("Enter Item CallNumber.  This is usually found in the front cover of your book (ex. 578.3S)");
            try
            {
                CDCallNumber = ILibraryItem.ParseCallNumbers(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("Invalid CallNumber");
            }
        }
        Int64 CDBarcode;
        while (true)
        {
            Console.WriteLine("Enter Barcode");
            try
            {
                CDBarcode = ILibraryItem.ParseBarcodes(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("invalid Barcode.  Must be 12 digits.");
            }
        }
        Console.WriteLine("Enter Item Title");
        string CDTitle = Console.ReadLine();
        Console.WriteLine("Enter Artist Name");
        string CDAuthor = Console.ReadLine();

        CD NewCDItem = new CD(CDCallNumber, CDTitle, CDAuthor, CDBarcode);

        return NewCDItem;

    }
}