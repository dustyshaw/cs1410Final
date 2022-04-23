using NUnit.Framework;
using MyLibrary.lib;
using System;

namespace tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
       // "587.B35", "Gone With the Wind", 1245670000000, "Margaret Mitchell", 34230000109820
        newBook = new Book();
        newBook.CallNumber = "587.B35";
        newBook.Author = "Margaret Mitchell";
        newBook.Barcode = 1245670000000;
        newBook.Title = "Gone With the Wind";
        newBook.ISBN = 3423000010982;

        //"989.a98", "Photos of the Ages", 1989763876, "Carmal Machiato", 9998987698798
        newOVBook = new OversizedBook();
        newOVBook.CallNumber = "989.a98";
        newOVBook.Title = "Photos of the Ages";
        newOVBook.Barcode = 1989763876;
        newOVBook.Author = "Carmal Machiato";
        newOVBook.ISBN = 9998987698798;

        //"873.a87", "Gone With the Wind Soundtrack", "Johnny Bob", 90876095876
        newCD = new CD();
        newCD.CallNumber = "873.a87";
        newCD.Title = "Gone With the Wind Soundtrack";
        newCD.Artist = "Johnny Bob";
        newCD.Barcode = 90876095876;

        newAccount = new Account("Dusty", "Shaw", 12345);
    }

    Book newBook;
    OversizedBook newOVBook;
    CD newCD;
    Account newAccount;


    [Test]
    public void Testing_BookConstruction()
    {
        Assert.AreEqual("587.B35", newBook.CallNumber);
        Assert.AreEqual("Gone With the Wind", newBook.Title);
        Assert.AreEqual(3423000010982, newBook.ISBN);
        Assert.AreEqual("Margaret Mitchell", newBook.Author);
    }

    [Test]
    public void Testing_CDConstruction()
    {
        Assert.AreEqual("873.a87", newCD.CallNumber);
        Assert.AreEqual("Gone With the Wind Soundtrack", newCD.Title);
        Assert.AreEqual("Johnny Bob", newCD.Artist);
    }

    [Test]
    public void Testing_Item_Availability_After_CheckOut()
    {
        newBook.CheckOut((ILibraryItem)newBook, newAccount);
        Assert.AreEqual(ItemAvailability.CheckedOut, newBook.Availability);
    }

    // [Test]
    // public void Testing_Renew_Function()
    // {
    //     var DueDate = new DateTime(2022-05-12);
    //     newBook.Renew((ILibraryItem)newBook);
    //     Assert.AreEqual(DueDate, newBook.DueDate);
    // }

    [Test]
    public void Testing_Patron_HoldList_After_CheckOut()
    {
        newBook.CheckOut((ILibraryItem)newBook, newAccount);
        Assert.AreEqual(newBook, newAccount.holdList[0]);
    }

    [Test]
    public void Testing_Patron_HoldList_After_2CheckOuts()
    {
        Book newBook2 = new Book();
        newBook2.CallNumber = "555.aaa";
        newBook2.Author = "John Doe";
        newBook2.Barcode = 1234567890;
        newBook2.Title = "Book2";
        newBook2.ISBN = 123456789070;

        newBook.CheckOut((ILibraryItem)newBook, newAccount);
        newBook2.CheckOut((ILibraryItem)newBook2, newAccount);
        Assert.AreEqual(newBook, newAccount.holdList[0]);
        Assert.AreEqual(newBook2, newAccount.holdList[1]);
    }

    [Test]
    public void Testing_Patron_HoldList_After_CheckIn()
    {
        newBook.CheckOut((ILibraryItem)newBook, newAccount);
        newBook.CheckIn((ILibraryItem)newBook, newAccount);
        Assert.AreEqual(newAccount.holdList.Count, 0);
    }

    [Test]
    public void Testing_Patron_HoldList_After_CheckIn_OneItem()
    {
        Book newBook2 = new Book();
        newBook2.CallNumber = "555.aaa";
        newBook2.Author = "John Doe";
        newBook2.Barcode = 1234567890;
        newBook2.Title = "Book2";
        newBook2.ISBN = 123456789070;

        newBook.CheckOut((ILibraryItem)newBook, newAccount);
        newBook2.CheckOut((ILibraryItem)newBook2, newAccount);

        newBook.CheckIn((ILibraryItem)newBook, newAccount);

        Assert.AreEqual(1, newAccount.holdList.Count);
        Assert.AreEqual(newBook2, newAccount.holdList[0]);
    }

    [Test]
    public void Testing_OVBook_GetType()
    {
        Assert.AreEqual(ItemType.OversizedBook, newOVBook.GetItemType());
    }

    [Test]
    public void Testing_OVBook_GetDetails()
    {
        Assert.AreEqual($"\n \n Item Type: {newOVBook.GetItemType()} \n CallNumber: {newOVBook.CallNumber} \n Title: {newOVBook.Title} \n Author: {newOVBook.Author} \n ISBN: {newOVBook.ISBN} \n Barcode: {newOVBook.Barcode} \n Availabilty: {newOVBook.Availability}"
                , newOVBook.GetDetails());
    }

    [Test]
    public void Testing_CD_GetType()
    {
        Assert.AreEqual(ItemType.CD, newCD.GetItemType());
    }

    [Test]
    public void Testing_Book_GetType()
    {
        Assert.AreEqual(ItemType.Book, newBook.GetItemType());
    }

}
