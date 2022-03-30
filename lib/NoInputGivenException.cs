namespace MyLibrary.lib;

public class NoInputGivenException : Exception
        {
            public NoInputGivenException(string message)
            {
                throw new NoInputGivenException(message);
            }
        }
