namespace Restaurant;

public class User{

    public string ?Email {get; set;}
    public string ?Password {get; set;}
    public string ?PhoneNumber {get; set;}
    public bool HasRervering {get; set;}
    public List<Table> ?TableRes {get; set;}

}