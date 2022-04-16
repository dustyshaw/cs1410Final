namespace MyLibrary.lib;
public class Account
{
    public Account(string _FirstName, string _LastName, int _ID)
    {
        this.FirstName = _FirstName;
        this.LastName = _LastName;
        this.ID = _ID;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int ID { get; set; }

    public List<ILibraryItem> holdList = new List<ILibraryItem>();

    public void DisplayHoldsList()
    {
        for (int i = 0; i < holdList.Count; i++)
        {
            Console.WriteLine(holdList[i].GetDetails().ToString());
        }
    }

    public string GetAccountDetails()
    {
        return $"\n First Name: {FirstName} \n Last Name: {LastName} \n Account ID: {ID} \n Holds List: {DisplayHoldsList}";
    }

    public static int ParsePatronID(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException();
        }
        return int.Parse(input);
    }
}