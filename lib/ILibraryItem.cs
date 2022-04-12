namespace MyLibrary.lib;

public interface ILibraryItem
{
    public string Title { get; set; }

    public string CallNumber { get; set; }

    public string CheckOut(ILibraryItem item, Account account);

    public string CheckIn(ILibraryItem item, Account account);

    public string Renew(ILibraryItem item);

    public string GetDetails();

    public static string ParseCallNumbers(string input)
    {
        if (input.Contains("."))
        {
            string[] callNumberParts = input.Split(".");
            int numVal = Int32.Parse(callNumberParts[0]);
            if (numVal < 0 || numVal > 999)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        if (input == null)
        {
            throw new ArgumentNullException();
        }
        return "input accepted";
    }
}
