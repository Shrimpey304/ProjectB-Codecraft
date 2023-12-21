namespace Restaurant;

public abstract class MasterLogin{
    protected const string filePath = @".\dataStorage\account.json";
    public abstract void LogOut(User user);
}