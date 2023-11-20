using System;
using System.IO;

namespace Restaurant
{
    public class MakeAdminAccs
    {
        public static void AddUser()
        {
            Console.WriteLine("Enter the information (email, name, id, password, phonenumber) to make an account.");
            Console.WriteLine("Enter user information:");

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Name: ");
            string naam = Console.ReadLine()!;

            Console.Write("ID: ");
            string id = Console.ReadLine()!;

            Console.Write("Password: ");
            string password = Console.ReadLine()!;

            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine()!;

            WriteToJson("MakeAccs.json", email, naam, id, password, phoneNumber);
        }

        static void WriteToJson(string fileName, string email, string naam, string id, string password, string phoneNumber)
        {
            Console.WriteLine("Adding a new user...");

            // Construct the JSON string with indentation
            string json = $"{{\n  \"Email\": \"{email}\",\n  \"Naam\": \"{naam}\",\n  \"ID\": \"{id}\",\n  \"Password\": \"{password}\",\n  \"PhoneNumber\": \"{phoneNumber}\"\n}}";

            // Append the JSON to the file
            File.AppendAllText(fileName, json + Environment.NewLine);

            Console.WriteLine("User added successfully!");

            ChangeAccMenu.DisplayChangeAccMenu();
        }
    }
}




