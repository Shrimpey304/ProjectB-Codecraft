namespace Restaurant.models;

public class DisplayConfigs
{
    public string Decorator{get;set;}
    public string OptionColor{get;set;}

    public DisplayConfigs(string decorator, string optioncolor)
    {
        Decorator = decorator;
        OptionColor = optioncolor;
    }

    public override string ToString()
    {
        return $"default option{OptionColor}"+$" decorator color{Decorator}";
    }
}
