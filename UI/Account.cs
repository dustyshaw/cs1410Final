namespace MyLibrary
{
    internal partial class Program
    {
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
            public static int numOfHoldsDefault = 0;
            public int[] holdList = new int[numOfHoldsDefault];
        }
    }
}
