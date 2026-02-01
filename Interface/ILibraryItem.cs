namespace LibraryManagementExtended.Interface
{
    public interface ILibraryItem
    {
        string Title { get; set; }
        string Publisher { get; set; }
        int PublicationYear { get; set; }

        string DisplayInfo();
        string ToFileString();
    }
}
