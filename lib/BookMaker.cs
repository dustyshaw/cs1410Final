using MyLibrary.lib;

public class BookMaker
{
    public static Book BookMakerforLibrary(string Title, string Author, string CallNumber, Int64 ISBN, Int64 Barcode)
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
