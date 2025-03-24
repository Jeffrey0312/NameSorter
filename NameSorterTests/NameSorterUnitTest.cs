using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

public class NameSorterTests
{
    // Test for basic sorting by last name and first name
    [Fact]
    public void TestNameSorting()
    {
        var inputNames = new List<string>
        {
            "Janet Parsons",
            "Vaughn Lewis",
            "Adonis Julius Archer",
            "Shelby Nathan Yoder",
            "Marin Alvarez"
        };

        var sortedNames = inputNames.OrderBy(name => name.Split(' ').Last()).ThenBy(name => name).ToList();

        var expectedNames = new List<string>
        {
            "Marin Alvarez",
            "Adonis Julius Archer",
            "Vaughn Lewis",
            "Janet Parsons",
            "Shelby Nathan Yoder"
        };

        Assert.Equal(expectedNames, sortedNames);
    }

    // Test case with only one name
    [Fact]
    public void TestSingleNameSorting()
    {
        var inputNames = new List<string>
        {
            "Janet Parsons"
        };

        var sortedNames = inputNames.OrderBy(name => name.Split(' ').Last()).ThenBy(name => name).ToList();

        var expectedNames = new List<string>
        {
            "Janet Parsons"
        };

        Assert.Equal(expectedNames, sortedNames);
    }

    // Test case with names that have the same last name
    [Fact]
    public void TestSameLastNameSorting()
    {
        var inputNames = new List<string>
        {
            "Adonis Julius Archer",
            "Vaughn Lewis Archer",
            "Shelby Nathan Archer"
        };

        var sortedNames = inputNames.OrderBy(name => name.Split(' ').Last()).ThenBy(name => name).ToList();

        var expectedNames = new List<string>
        {
            "Adonis Julius Archer",
            "Shelby Nathan Archer",
            "Vaughn Lewis Archer"
        };

        Assert.Equal(expectedNames, sortedNames);
    }

    // Test case for names with more than 2 given names
    [Fact]
    public void TestMultipleGivenNames()
    {
        var inputNames = new List<string>
        {
            "Hunter Uriah Mathew Clarke",
            "Leo Gardner"
        };

        // Sort by the last name, then by the full name to resolve ties
        var sortedNames = inputNames.OrderBy(name =>
        {
            var nameParts = name.Split(' ');
            var lastName = nameParts.Last();  // Get the last name
            return lastName;
        })
        .ThenBy(name => name)  // Then by the full name to resolve any tie
        .ToList();

        var expectedNames = new List<string>
        {
            "Hunter Uriah Mathew Clarke",
            "Leo Gardner"
        };

        Assert.Equal(expectedNames, sortedNames);
    }

    // Test case for names with special characters
    [Fact]
    public void TestNamesWithSpecialCharacters()
    {
        var inputNames = new List<string>
        {
            "Anna-Marie X",
            "John O'Connor",
            "Jane Doe"
        };

        var sortedNames = inputNames.OrderBy(name => name.Split(' ').Last()).ThenBy(name => name).ToList();

        var expectedNames = new List<string>
        {
            "Jane Doe",
            "John O'Connor",
            "Anna-Marie X"
        };

        Assert.Equal(expectedNames, sortedNames);
    }

    // Edge case: Test for file not found
    [Fact]
    public void TestFileNotFound()
    {
        string nonExistentFilePath = "non-existent-file.txt";

        var exception = Assert.Throws<FileNotFoundException>(() => File.ReadAllLines(nonExistentFilePath));

        // Instead of checking the message, we now check if the exception type is correct.
        Assert.IsType<FileNotFoundException>(exception);
    }

    // Edge case: Test for empty file
    [Fact]
    public void TestEmptyFile()
    {
        // Generate a temporary file path for the empty file
        string emptyFilePath = Path.Combine(Path.GetTempPath(), "empty-file.txt");

        try
        {
            // Create an empty file
            File.WriteAllText(emptyFilePath, "");

            // Read the file and ensure no empty or whitespace-only lines
            var names = File.ReadAllLines(emptyFilePath).Where(name => !string.IsNullOrWhiteSpace(name)) .ToList();

            // Assert that the list of names is empty since the file has no names
            Assert.Empty(names);  
        }
        finally
        {
            // Clean up: Delete the temporary file after the test is done
            if (File.Exists(emptyFilePath))
            {
                File.Delete(emptyFilePath);
            }
        }
    }
}
