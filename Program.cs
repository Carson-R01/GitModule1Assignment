using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // The name of the file where we save the data
        string filePath = "SuperMarioCharacters.txt";

        while (true) // Keep showing the menu until the user chooses to exit
        {
            Console.Clear(); // Clear the screen for a clean menu
            Console.WriteLine("Super Mario Characters App");
            Console.WriteLine("1. Add a Character");
            Console.WriteLine("2. View All Characters");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option (1-3): ");
            string choice = Console.ReadLine(); // Get the user's choice

            if (choice == "1")
            {
                AddCharacter(filePath); // Call the AddCharacter method
            }
            else if (choice == "2")
            {
                ViewCharacters(filePath); // Call the ViewCharacters method
            }
            else if (choice == "3")
            {
                break; // Exit the loop and end the program
            }
            else
            {
                Console.WriteLine("Invalid option! Press any key to try again.");
                Console.ReadKey(); // Wait for the user to press a key
            }
        }
    }

    static void AddCharacter(string filePath)
    {
        Console.Clear(); // Clear the screen
        Console.WriteLine("Add a New Character");

        // Ask the user for character details
        Console.Write("Enter Id: ");
        string id = Console.ReadLine();

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Relationship to Mario: ");
        string relationship = Console.ReadLine();

        // Combine the details into one line
        string characterLine = $"{id},{name},{relationship}";

        // Save the line to the file
        File.AppendAllText(filePath, characterLine + Environment.NewLine);

        Console.WriteLine("Character added successfully!");
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey(); // Wait for the user to press a key
    }

    static void ViewCharacters(string filePath)
    {
        Console.Clear(); // Clear the screen
        Console.WriteLine("All Characters:");

        // Check if the file exists
        if (File.Exists(filePath))
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);

            // Go through each line and display the character details
            foreach (string line in lines)
            {
                string[] parts = line.Split(','); // Split the line into parts
                Console.WriteLine($"Id: {parts[0]}");
                Console.WriteLine($"Name: {parts[1]}");
                Console.WriteLine($"Relationship to Mario: {parts[2]}");
                Console.WriteLine(); // Empty line for spacing
            }

            // Show how many characters were saved
            Console.WriteLine($"{lines.Length} characters saved to file.");
        }
        else
        {
            // File doesn't exist yet
            Console.WriteLine("No characters found. Add some first!");
        }

        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey(); // Wait for the user to press a key
    }
}