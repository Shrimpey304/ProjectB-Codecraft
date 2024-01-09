namespace Restaurant;

public class User{

    public string ?Email {get; set;}
    public string ?Password {get; set;}
    public string ?PhoneNumber {get; set;}
    public bool HasRervering {get; set;}
    public Dictionary<string, Table> tableHistory = new();
    public bool Admin { get; set; }

    public User(string newEmail, string newPassword, string newPhoneNumber, bool newAdminStatus)
    {
        Email = newEmail;
        Password = newPassword;
        PhoneNumber = newPhoneNumber;
        Admin = newAdminStatus;
    }

    public override int GetHashCode()
    {
        return (Email, PhoneNumber, Password).GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return GetHashCode() == obj.GetHashCode();
    }
}



