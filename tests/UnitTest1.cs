using lib;
using NUnit.Framework;


namespace tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void CreatingABookTest()
    {
        Book newBook = new Book(12345, "Gone With the Wind", "Margaret Mitchell");
        Assert.AreEqual(12345, newBook.ID);
    }
}