using System;
using LibraryManagementExtended.CustomException;
using LibraryManagementExtended.Interface;

namespace LibraryManagementExtended.Abstraction
{
    public abstract class LibraryItemBase : ILibraryItem
    {
        private string title;
        private string publisher;
        private int publicationYear;

        public string Title
        {
            get => title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Title cannot be empty.");
                title = value;
            }
        }

        public string Publisher
        {
            get => publisher;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Publisher cannot be empty.");
                publisher = value;
            }
        }

        public int PublicationYear
        {
            get => publicationYear;
            set
            {
                if (value < 1500 || value > DateTime.Now.Year)
                    throw new InvalidItemDataException("Invalid publication year.");
                publicationYear = value;
            }
        }

        public abstract string DisplayInfo();
        public abstract string ToFileString();
    }
}
