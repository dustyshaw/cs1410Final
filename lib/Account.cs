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
    //public static int numOfHoldsDefault = 0;
    public List<ICheckoutable> holdList = new List<ICheckoutable>();

    public string DisplayHoldsList()
    {
        return holdList[0].GetDetails();
    }

    public string GetAccountDetails()
    {
        return $"\n First Name: {FirstName} \n Last Name: {LastName} \n Account ID: {ID} \n Holds List: {DisplayHoldsList()}";
    }

    // public void Load()
    // {

    // }

    // public void Save()
    // {

    // }
}