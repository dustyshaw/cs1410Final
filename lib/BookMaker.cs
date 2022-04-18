using MyLibrary.lib;

public class BookMaker
{
    public static Book BookMakerforLibrary()
    {
        string CallNumber;
        while (true)
        {
            Console.WriteLine("Enter Item CallNumber.  This is usually found in the front cover of your book (ex. 578.3S)");
            try
            {
                CallNumber = ILibraryItem.ParseCallNumbers(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("Invalid CallNumber");
            }
        }
        Console.WriteLine("Enter Item Title");
        string Title = Console.ReadLine();
        Console.WriteLine("Enter Authors Full Name");
        string Author = Console.ReadLine();
        Int64 ISBN;
        while (true)
        {
            Console.WriteLine("Enter ISBN");
            try
            {
                ISBN = ILibraryItem.ParseISBN(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("invalid ISBN.  Must be 10 or 13 digits.");
            }
        }

        Int64 Barcode;
        while (true)
        {
            Console.WriteLine("Enter Barcode");
            try
            {
                Barcode = ILibraryItem.ParseBarcodes(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("invalid Barcode.  Must be 12 digits.");
            }
        }

        Book NewBookItem = new Book(CallNumber, Title, ISBN, Author, Barcode);
        return NewBookItem;
    }
}