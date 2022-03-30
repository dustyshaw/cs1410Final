using NUnit.Framework;
using MyLibrary.lib;

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
        Book newBook = new Book("587.B35", "Gone With the Wind", 124567, "Margaret Mitchell");
        Assert.AreEqual("587.B35", newBook.CallNumber);
    }
}