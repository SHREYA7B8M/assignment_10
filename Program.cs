using System;
using System.IO;

class Program
{
   static string path = @"C:\Users\KIIT\Desktop\Git Exercise\Day_8\assignment_10\FileAssignment\";

    static void Main()
    {
        Console.WriteLine("File Handling Mechanism");
        Console.WriteLine("--------------------------");
        Console.WriteLine("1. Create new text file");
        Console.WriteLine("2. Read the content of an existing text file");
        Console.WriteLine("3. Append additional content to an existing text file");
        Console.WriteLine("4. Delete an existing text file");
        Console.WriteLine("5. Exit");

        while (true)
        {
            string choice;
            string createFileName;
            Console.Write("Enter your choice in between 1 to 5: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Input filename: ");
                    createFileName = Console.ReadLine();
                    Console.Write("Enter the content: ");
                    string createFileContent = Console.ReadLine();
                    CreateFile(Path.Combine(path, createFileName), createFileContent);
                    break;

                case "2":
                    Console.Write("Enter the filename to read: ");
                    string readFileName = Console.ReadLine();
                    ReadFile(Path.Combine(path, readFileName));
                    break;

                case "3":
                    Console.Write("Enter the filename to append: ");
                    string appendFileName = Console.ReadLine();
                    Console.Write("Enter the content to append: ");
                    string appendContent = Console.ReadLine();
                    AppendToFile(Path.Combine(path, appendFileName), appendContent);
                    break;

                case "4":
                    Console.Write("Enter the filename to delete: ");
                    string deleteFileName = Console.ReadLine();
                    DeleteFile(Path.Combine(path, deleteFileName));
                    break;

                    case "5":
                    Console.WriteLine("Exit from File Handling Mechanism!!");
                    return;
                   
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void CreateFile(string fileName, string content)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(content);
            }
            Console.WriteLine("File created successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while creating the file: {ex.Message}");
        }
    }

    static void ReadFile(string fileName)
    {
        try
        {
            if (File.Exists(fileName))
            {
                string content = File.ReadAllText(fileName);
                Console.WriteLine("File content:");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while reading the file: {ex.Message}");
        }
    }

    static void AppendToFile(string fileName, string content)
    {
        try
        {
            using (StreamWriter writer = File.AppendText(fileName))
            {
                writer.WriteLine(content);
            }
            Console.WriteLine("Content appended successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while appending to the file: {ex.Message}");
        }
    }

    static void DeleteFile(string fileName)
    {
        try
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                Console.WriteLine("File deleted successfully!");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while deleting the file: {ex.Message}");
        }
    }
}
