using MyLibrary.lib;

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