using LibraryManagementExtended.Services;

class Program
{
    static void Main(string[] args)
    {
        var service = new LibraryService();
        service.RunMenu();
    }
}
