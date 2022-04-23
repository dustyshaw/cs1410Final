namespace MyLibrary.lib;

public class CD : ILibraryItem
{
    public string CallNumber { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public Int64 Barcode { get; set; }
    public DateTime DueDate { get; set; }
    public ItemAvailability Availability { get; set; }
    public CD()
    {
    }
    public string CheckOut(ILibraryItem item, Account account)
    {
        var castedItem = (CD)item;
        castedItem.Availability = ItemAvailability.CheckedOut;
        var DueDate = DateTime.Today.AddDays(21);
        account.holdList.Add(castedItem);

        return ("Item successfully checked out to: " + account.FirstName + " " + account.LastName + ".");
    }
    public string CheckIn(ILibraryItem item, Account account)
    {
        var castedItem = (CD)item;
        account.holdList.Remove(castedItem);
        castedItem.Availability = ItemAvailability.CheckedIn;
        return ("Item successfully checked in.");
    }
    public string Renew(ILibraryItem item)
    {
        var bookitem = (CD)item;
        this.DueDate = DateTime.Today.AddDays(21);
        return ("Item successfully renewed. Now due on: " + DueDate);
    }
    public string GetDetails()
    {
        return $"\n \n Item Type: {GetItemType()} \n CallNumber: {CallNumber} \n Title: {Title} \n Artist: {Artist} \n Availability: {this.Availability} \n";
    }

    public async void WriteToTextFile(ILibraryItem item)
    {
        using StreamWriter file = new("data.txt", append: true);
        await file.WriteLineAsync(item.GetDetails());
    }

    public ItemType GetItemType()
    {
        return ItemType.CD;
    }
}