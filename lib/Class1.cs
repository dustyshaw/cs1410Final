namespace lib;
public interface ILibraryItem
{
    public string CheckOut();
}
public class Book
{
    public int ID;
    public string v2;
    public string v3;

    public Book(int v1, string v2, string v3)
    {
        this.ID = v1;
        this.v2 = v2;
        this.v3 = v3;
    }
}
