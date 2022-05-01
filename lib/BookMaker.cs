using MyLibrary.lib;

public class BookMaker
{
    public static Book BookMakerforLibrary(string CallNumber, string Title, string Author, Int64 Barcode, Int64 ISBN)
    {
        Book NewBookItem = new Book();
        NewBookItem.Author = Author;
        NewBookItem.CallNumber = CallNumber;
        NewBookItem.Title = Title;
        NewBookItem.ISBN = ISBN;
        NewBookItem.Barcode = Barcode;
        return NewBookItem;
    }
}
