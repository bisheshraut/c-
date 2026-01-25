using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    // ---------- Custom Exceptions ----------
    class InvalidItemDataException : Exception
    {
        public InvalidItemDataException(string message) : base(message) { }
    }

    class DuplicateItemException : Exception
    {
        public DuplicateItemException(string message) : base(message) { }
    }

    // ---------- Base Class ----------
    abstract class Item
    {
        private string title;
        private string publisher;
        private int publicationYear;

        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Title cannot be empty.");
                title = value;
            }
        }

        public string Publisher
        {
            get { return publisher; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Publisher cannot be empty.");
                publisher = value;
            }
        }

        public int PublicationYear
        {
            get { return publicationYear; }
            set
            {
                if (value < 1500 || value > DateTime.Now.Year)
                    throw new InvalidItemDataException("Invalid publication year.");
                publicationYear = value;
            }
        }

        // Polymorphic method
        public abstract void DisplayInfo();
    }

    // ---------- Derived Class: Book ----------
    class Book : Item
    {
        private string author;

        public string Author
        {
            get { return author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Author cannot be empty.");
                author = value;
            }
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("\n--- Book Details ---");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Publisher: {Publisher}");
            Console.WriteLine($"Year: {PublicationYear}");
        }
    }

    // ---------- Derived Class: Magazine ----------
    class Magazine : Item
    {
        private int issueNumber;

        public int IssueNumber
        {
            get { return issueNumber; }
            set
            {
                if (value <= 0)
                    throw new InvalidItemDataException("Issue number must be positive.");
                issueNumber = value;
            }
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("\n--- Magazine Details ---");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Issue Number: {IssueNumber}");
            Console.WriteLine($"Publisher: {Publisher}");
            Console.WriteLine($"Year: {PublicationYear}");
        }
    }

    // ---------- Main Program ----------
    class Program
    {
        static List<Item> libraryItems = new List<Item>();

        static void Main(string[] args)
        {
            try
            {
                Book book = new Book
                {
                    Title = "C# Programming",
                    Author = "John Smith",
                    Publisher = "Tech Press",
                    PublicationYear = 2022
                };

                AddItem(book);

                Magazine magazine = new Magazine
                {
                    Title = "Tech Monthly",
                    IssueNumber = 5,
                    Publisher = "Media House",
                    PublicationYear = 2023
                };

                AddItem(magazine);

                // Display all items using polymorphism
                foreach (Item item in libraryItems)
                {
                    item.DisplayInfo();
                }
            }
            catch (InvalidItemDataException ex)
            {
                Console.WriteLine($"Input Error: {ex.Message}");
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Duplicate Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nProgram execution completed.");
            }
        }

        static void AddItem(Item item)
        {
            foreach (Item existingItem in libraryItems)
            {
                if (existingItem.Title == item.Title)
                {
                    throw new DuplicateItemException("Item already exists in the library.");
                }
            }

            libraryItems.Add(item);
        }
    }
}
