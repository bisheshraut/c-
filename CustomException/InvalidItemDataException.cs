using System;

namespace LibraryManagementExtended.CustomException
{
    public class InvalidItemDataException : Exception
    {
        public InvalidItemDataException(string message) : base(message) { }
    }
}
