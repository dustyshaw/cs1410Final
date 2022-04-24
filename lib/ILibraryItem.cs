using System;
namespace MyLibrary.lib;

public interface ILibraryItem
{
    public string Title { get; set; }

    public string CallNumber { get; set; }

    public string CheckOut(ILibraryItem item, Account account);

    public string CheckIn(ILibraryItem item, Account account);

    public string Renew(ILibraryItem item);

    public string GetDetails();

    public static string ParseCallNumbers(string input, Library SnowCollegeLibrary)
    {
        if (!input.Contains("."))
        {
            var numMaxCharacters = 1000000;
            int i = 0;
            char[] characters = input.ToCharArray();
            foreach (char character in characters)
            {
                if (Char.IsDigit(character))
                {
                    int[] digits = new int[numMaxCharacters];
                    digits[i] = character;
                    i++;
                }
            }
        }
        if (input.Contains("."))
        {
            string[] callNumberParts = input.Split(".");
            int numVal = Int32.Parse(callNumberParts[0]);
            if (numVal < 0 || numVal > 999)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        if (input == null)
        {
            throw new ArgumentNullException();
        }
        if (SnowCollegeLibrary.LibraryItemList.ContainsKey(input))
        {
            throw new DuplicateWaitObjectException();
        }
        return input;
    }

    public static Int64 ParseBarcodes(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException();
        }

        if (input.Length != 12)
        {
            throw new ArgumentOutOfRangeException();
        }

        return Int64.Parse(input);
    }

    public static Int64 ParseISBN(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException();
        }
        if (input.Length != 10 && input.Length != 13)
        {
            throw new ArgumentOutOfRangeException();
        }
        return Int64.Parse(input);
    }

    public static string ParseSearchRequest(string input, Library SnowCollegeLibrary)
    {
        foreach (KeyValuePair<string, ILibraryItem> item in SnowCollegeLibrary.LibraryItemList)
        {
            if (item.Value.Title != input && item.Key != input)
            {
                throw new KeyNotFoundException();
            }
            
            // if (item.Key != input)
            // {
            //     throw new KeyNotFoundException();
            // }
        }
        return input;
    }
}
