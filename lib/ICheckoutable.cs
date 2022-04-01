namespace MyLibrary.lib;

public interface ICheckoutable
{
    public string Title { get; }
    public string CallNumber { get; }
    public string GetDetails();
    public string CheckOut(ICheckoutable item, Account account, int[] holdList);
    public string CheckIn(ICheckoutable item);
    //public DateTime DueDate{get; set;}
}
