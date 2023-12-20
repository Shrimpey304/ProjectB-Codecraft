 namespace Restaurant;

public class UserChangeAcc
{
    public static void UserSeeOwnAcc(string email)
        {
            Console.WriteLine(email);
        }

    public static void ChangeEmailU()
        {
            Console.WriteLine("Enter new email:");
            string newEmail = Console.ReadLine();

            Console.WriteLine("Email changed successfully!");
        }

    public static void ChangePasswordU()
        {
            Console.WriteLine("Enter new password:");
            string newPassword = Console.ReadLine();

            Console.WriteLine("Password changed successfully!");
        }

    public static void ChangePhoneNumberU()
        {
            Console.WriteLine("Enter new phone number:");
            string newPhoneNumber = Console.ReadLine();

            Console.WriteLine("Phone number changed successfully!");
        }

}