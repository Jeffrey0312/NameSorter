Name Sorter

Overview

Name Sorter is a .NET Core console application that sorts a list of names based on their last name, followed by given names in case of a tie. The sorted names are printed to the console and saved to an output file.

Features

Reads a list of names from a file.

Sorts names based on the last name, then given names.

Outputs sorted names to the console.

Saves the sorted list to sorted-names-list.txt.

Includes unit tests to verify sorting correctness.

Usage

Prerequisites

.NET 8.0 SDK installed on your system

A text file containing names (one name per line)

Running the Program

Navigate to the project directory.

Execute the following command:

dotnet run -- ./unsorted-names-list.txt

Replace ./unsorted-names-list.txt with the path to your input file.

The sorted names will be displayed in the console and saved in sorted-names-list.txt.

Example

Input (unsorted-names-list.txt)

Janet Parsons
Vaughn Lewis
Adonis Julius Archer
Shelby Nathan Yoder
Marin Alvarez
London Lindsey
Beau Tristan Bentley
Leo Gardner
Hunter Uriah Mathew Clarke
Mikayla Lopez
Frankie Conner Ritter

Output (sorted-names-list.txt)

Marin Alvarez
Adonis Julius Archer
Beau Tristan Bentley
Hunter Uriah Mathew Clarke
Leo Gardner
Vaughn Lewis
London Lindsey
Mikayla Lopez
Janet Parsons
Frankie Conner Ritter
Shelby Nathan Yoder


Testing

To run the unit tests, execute:

cd NameSorterTests

dotnet test

This will execute all tests and verify the correctness of the sorting logic.

Code Quality & SOLID Principles

Single Responsibility Principle: The program separates concerns between reading files, sorting names, and displaying results.

Open/Closed Principle: Sorting logic can be extended without modifying core code.

Liskov Substitution Principle: Ensures any extension of sorting logic can be substituted without breaking the application.

Interface Segregation Principle: The functionality is divided appropriately without unnecessary dependencies.

Dependency Inversion Principle: Uses dependency injection (if extended for scalability).


Author

Ke Lin
