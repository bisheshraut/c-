using LibraryManagementExtended.Abstraction;
using LibraryManagementExtended.CustomException;

namespace LibraryManagementExtended.Model
{
    public class Book : LibraryItemBase
    {
        private string author;
        public string Author
        {
            get => author;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Author cannot be empty.");
                author = value;
            }
        }

        public override string DisplayInfo()
        {
            return $"[Book] {Title} by {Author}, {Publisher} ({PublicationYear})";
        }

        public override string ToFileString()
        {
            return $"Book,{Title},{Publisher},{PublicationYear},{Author}";
        }
    }
}
