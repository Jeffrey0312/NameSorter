using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Name Sorter - A console application that sorts a list of names based on last name, then given names.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: name-sorter <file-path>");
            return;
        }

        string inputFilePath = args[0];
        string outputFilePath = "sorted-names-list.txt";

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"Error: File '{inputFilePath}' not found.");
            return;
        }

        try
        {
            var names = ReadNamesFromFile(inputFilePath);
            var sortedNames = SortNames(names);
            
            PrintNames(sortedNames);
            WriteNamesToFile(outputFilePath, sortedNames);

            Console.WriteLine($"Sorted names saved to {Path.GetFullPath(outputFilePath)}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Permission error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    /// <summary>
    /// Reads names from a file and returns a cleaned list.
    /// </summary>
    static List<string> ReadNamesFromFile(string filePath)
    {
        return File.ReadAllLines(filePath).Select(name => name.Trim()).Where(name => !string.IsNullOrWhiteSpace(name)).ToList();
    }

    /// <summary>
    /// Sorts names by last name, then by full name.
    /// </summary>
    static List<string> SortNames(List<string> names)
    {
        // Sort by last name then by full name for tie-breaking
        return names.OrderBy(name => name.Split(' ').Last()).ThenBy(name => name).ToList();
    }

    /// <summary>
    /// Prints the names to the console.
    /// </summary>
    static void PrintNames(List<string> names)
    {
        names.ForEach(Console.WriteLine);
    }

    /// <summary>
    /// Writes the sorted names to a file.
    /// </summary>
    static void WriteNamesToFile(string filePath, List<string> names)
    {
        File.WriteAllLines(filePath, names);
    }
}
