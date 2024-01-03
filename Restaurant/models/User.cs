namespace Restaurant;

public class User{

    public string ?Email {get; set;}
    public string ?Password {get; set;}
    public string ?PhoneNumber {get; set;}
    public bool HasRervering {get; set;}
    public Dictionary<string, Table> tableHistory = new();
    public bool Admin { get; set; }

    public void ChangeEmail(string newEmail)
        {
            Email = newEmail;
        }

    public void ChangePassword(string newPassword)
        {
            Email = newPassword;
        }

    public void ChangePhonenumber(string newPhoneNumber)
        {
            PhoneNumber = newPhoneNumber;
        }

    public void ChangeAdminstatus(bool newAdminStatus)
        {
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


