using System;

namespace LibraryManagementExtended.CustomException
{
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException(string message) : base(message) { }
    }
}
