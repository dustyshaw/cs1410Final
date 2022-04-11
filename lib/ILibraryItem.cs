namespace MyLibrary.lib;

public interface ILibraryItem
{
    // public string Title { get; set; }

    // public string CallNumber { get; set; }  Do I really need these?

    public string CheckOut(ILibraryItem item, Account account);

    public string CheckIn(ILibraryItem item, Account account);

    public string Renew(ILibraryItem item);

    public string GetDetails();

}
