using NUnit.Framework;
using MyLibrary.lib;
using System;

namespace tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        // Book newBook = new Book("587.B35", "Gone With the Wind", "124567", "Margaret Mitchell", "34230000109820");
        // Account newAccount = new Account("Dusty", "Shaw", 12345);
    }

    [Test]
    public void TestingBookConstruction()
    {
        Book newBook = new Book("587.B35", "Gone With the Wind", "124567", "Margaret Mitchell", "34230000109820");
        Assert.AreEqual("587.B35", newBook.CallNumber);
        Assert.AreEqual("Gone With the Wind", newBook.Title);
        Assert.AreEqual("124567", newBook.ISBN);
        Assert.AreEqual("Margaret Mitchell", newBook.Author);
    }

    [Test]
    public void TestingCDConstruction()
    {
        Book newBook = new Book("587.B35", "Gone With the Wind", "124567", "Margaret Mitchell", "34230000109820");
        CD newCD = new CD("123.abc", "Circles", "Mac Miller");
        Assert.AreEqual("123.abc", newCD.CallNumber);
        Assert.AreEqual("Circles", newCD.Title);
        Assert.AreEqual("Mac Miller", newCD.Artist);
    }

    [Test]
    public void TestingItemAvailabilityAfterCheckOut()
    {
        Account newAccount = new Account("Dusty", "Shaw", 12345);
        Book newBook = new Book("587.B35", "Gone With the Wind", "124567", "Margaret Mitchell", "34230000109820");
        newBook.CheckOut((ILibraryItem)newBook, newAccount);
        Assert.AreEqual(ItemAvailability.CheckedOut, newBook.Availability);
    }

    [Test]
    public void TestingRenewFunction()
    {
        Book newBook = new Book("587.B35", "Gone With the Wind", "124567", "Margaret Mitchell", "34230000109820");
        var DueDate = new DateTime(2022, 4, 30);
        newBook.Renew((ILibraryItem)newBook);
        Assert.AreEqual(DueDate, newBook.DueDate);
    }

    [Test]
    public void TestingPatronsHoldListAfterCheckOut()
    {
        Account newAccount = new Account("Dusty", "Shaw", 12345);
        Book newBook = new Book("587.B35", "Gone With the Wind", "124567", "Margaret Mitchell", "34230000109820");
        newBook.CheckOut((ILibraryItem)newBook, newAccount);
        Assert.AreEqual(newBook, newAccount.holdList[0]);
    }

    [Test]
    public void TestingPatronsHoldListAfterCheckIn()
    {
        Account newAccount = new Account("Dusty", "Shaw", 12345);
        Book newBook = new Book("587.B35", "Gone With the Wind", "124567", "Margaret Mitchell", "34230000109820");
        newBook.CheckIn((ILibraryItem)newBook, newAccount);
        Assert.AreEqual(null, newAccount.holdList[0]);
    }
}
