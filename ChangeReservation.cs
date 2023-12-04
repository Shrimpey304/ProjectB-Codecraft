using System;
using System.IO;

namespace Restaurant
{
    public class ChangReservations
    {
        public static void ChangeResvInfo()
        {
            ShowAllReservations();
            UpdateResv();
        }

        static void ShowAllReservations()
        {
            Console.WriteLine("Showing all accounts...");
            string json = File.ReadAllText("Reservations.json");
            Console.WriteLine(json);
        }

        public static void UpdateResv()
        {
            Console.WriteLine("Type the ID of the reservation that you would like to update");
            string reservationId = Console.ReadLine()!;

            string filePath = "Reservations.json";
            string json = File.ReadAllText(filePath);

            int startIndex = json.IndexOf($"\"ID\": \"{reservationId}\"");

            if (startIndex == -1)
            {
                Console.WriteLine("Reservation not found.");
                return;
            }

            int endIndex = json.IndexOf('}', startIndex);

            if (endIndex == -1)
            {
                Console.WriteLine("Invalid JSON structure.");
                return;
            }

            int startBlock = json.LastIndexOf('{', startIndex);
            int endBlock = endIndex + 1;

            string reservationInfo = json.Substring(startBlock, endBlock - startBlock);
            string updatedResvInfo = UpdateResvDetails(reservationInfo);

            if (!string.IsNullOrEmpty(updatedResvInfo))
            {
                json = json.Remove(startBlock, endBlock - startBlock).Insert(startBlock, updatedResvInfo);

                File.WriteAllText(filePath, json);
                Console.WriteLine("Changes saved successfully.");
            }
            else
            {
                Console.WriteLine("Update failed.");
            }
        }

        static string UpdateResvDetails(string reservationInfo)
        {
            Console.WriteLine("What would you like to change?");
            Console.WriteLine("[E] ID");
            Console.WriteLine("[P] Status");
            Console.WriteLine("[H] Type");

            string choice = Console.ReadLine()?.ToUpper()!;

            switch (choice)
            {
                case "E":
                    Console.WriteLine("Enter new ID:");
                    reservationInfo = reservationInfo.Replace("ID", $"ID\": \"{Console.ReadLine()}\"");
                    break;
                case "P":
                    Console.WriteLine("Enter new status:");
                    reservationInfo = reservationInfo.Replace("Status", $"Status\": \"{Console.ReadLine()}\"");
                    break;
                case "H":
                    Console.WriteLine("Enter new Type:");
                    reservationInfo = reservationInfo.Replace("Type", $"Type\": \"{Console.ReadLine()}\"");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            return reservationInfo;
        }
    }
}