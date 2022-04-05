namespace MyLibrary.lib;

public interface ICheckoutable
{
    public string Title { get; }
    public string CallNumber { get; }
    public string CheckOut(ICheckoutable item, Account account);
    public string CheckIn(ICheckoutable item);
    //public DateTime DueDate{get; set;}
    public string GetDetails();
    public string Renew(ICheckoutable item);
}
