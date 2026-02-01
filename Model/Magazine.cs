using LibraryManagementExtended.Abstraction;
using LibraryManagementExtended.CustomException;

namespace LibraryManagementExtended.Model
{
    public class Magazine : LibraryItemBase
    {
        private int issueNumber;
        public int IssueNumber
        {
            get => issueNumber;
            set
            {
                if (value <= 0)
                    throw new InvalidItemDataException("Issue number must be positive.");
                issueNumber = value;
            }
        }

        public override string DisplayInfo()
        {
            return $"[Magazine] {Title}, Issue #{IssueNumber}, {Publisher} ({PublicationYear})";
        }

        public override string ToFileString()
        {
            return $"Magazine,{Title},{Publisher},{PublicationYear},{IssueNumber}";
        }
    }
}
