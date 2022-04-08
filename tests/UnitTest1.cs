using NUnit.Framework;
using MyLibrary.lib;
using System;

namespace tests;

public class Tests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void TestingBookConstruction()
    {
        Book newBook = new Book("587.B35", "Gone With the Wind", "124567", "Margaret Mitchell", "34230000109820");
        Assert.AreEqual("587.B35", newBook.CallNumber);
        Assert.AreEqual("Gone With the Wind", newBook.Title);
        Assert.AreEqual(124567, newBook.ISBN);
        Assert.AreEqual("Margaret Mitchell", newBook.Author);
    }

    [Test]
    public void TestingCDConstruction()
    {
        CD newCD = new CD("123.abc", "Circles", "Mac Miller");
        Assert.AreEqual("123.abc", newCD.CallNumber);
        Assert.AreEqual("Circles", newCD.Title);
        Assert.AreEqual("Mac Miller", newCD.Artist);
    }

    [Test]
    public void TestingItemAvailabilityAfterCheckOut()
    {
        Book newBook = new Book("587.B35", "Gone With the Wind", "124567", "Margaret Mitchell", "34230000109820");
        Account newAccount = new Account("Dusty", "Shaw", 12345);
        newBook.CheckOut((ICheckoutable)newBook, newAccount);
        Assert.AreEqual(ItemAvailability.CheckedOut, newBook.Availability);
    }

    [Test]
    public void TestingRenewFunction()
    {
        Book newBook = new Book("587.B35", "Gone With the Wind", "124567", "Margaret Mitchell", "34230000109820");
        var DueDate = new DateTime(2022, 4, 25);
        newBook.Renew((ICheckoutable)newBook);
        Assert.AreEqual(DueDate, newBook.DueDate);
    }
}