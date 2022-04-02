namespace MyLibrary.lib;

public class Library
{
    Dictionary<string, ICheckoutable> LibraryItemList = new Dictionary<string, ICheckoutable>();
    public string GetItem () 
    {
        throw new Exception();
    }

    public string GetAuthors()
    {
        throw new Exception();
    }

    public string GetItem(string searchPhrase) 
    {
        throw new Exception();
    }
}