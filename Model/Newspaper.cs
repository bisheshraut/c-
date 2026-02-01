using LibraryManagementExtended.Abstraction;
using LibraryManagementExtended.CustomException;

namespace LibraryManagementExtended.Model
{
    public class Newspaper : LibraryItemBase
    {
        private string editor;
        public string Editor
        {
            get => editor;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Editor cannot be empty.");
                editor = value;
            }
        }

        public override string DisplayInfo()
        {
            return $"[Newspaper] {Title}, Editor: {Editor}, {Publisher} ({PublicationYear})";
        }

        public override string ToFileString()
        {
            return $"Newspaper,{Title},{Publisher},{PublicationYear},{Editor}";
        }
    }
}
