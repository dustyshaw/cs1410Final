namespace MyLibrary.lib;

public class EAudioBook : AudioBook
{
    public decimal RunTime;
    public EAudioBook(string _CallNumber, string _Title, string _ISBN, string _Author, string _Barcode, decimal _RunTime) : base(_CallNumber, _Title, _ISBN, _Author, _Barcode)
    {
        this.RunTime = _RunTime;
    }
    public override string GetDetails()
    {
        return $"\n \n CallNumber: {CallNumber} Title: {Title} \n Author: {Author} \n ISBN: {ISBN} \n Item Type: {Type} \n Availabilty: {Availability} \n RunTime: {RunTime}";
    }
}
