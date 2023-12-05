namespace Restaurant;

public class Ingelogdmenu
{
    public User user;
    public void DisplayIngelogdMenu()
    {
        MakeReservation makeReservation = new(user);
        MenuCard menuCard = new();
        PersonalInfoTest personalProcess = new();
        List<string> LogedInMenuOptions = new(){
            "Menu (food)",
            "Restaurant informatie",
            "Make reservation",
            "Order history",
            "Personal information",
            "Logout"
        };
        List<Action> actions = new(){
            menuCard.FromMain,
            RestaurantInfoTest.DisplayRestaurantInfo,
            makeReservation.Display,
            OrderHistoryTest.DisplayOrderHistory,
            personalProcess.DisplayPIMenu,
            MainMenu.DisplayMainMenu
        };
        int selectedOption = DisplayUtil.Display(LogedInMenuOptions);
        switch (selectedOption)
        {
            case 0:
                menuCard.windowInstanceStack.Push(DisplayIngelogdMenu);
                break;
            case 2:
                makeReservation.windowInstanceStack.Push(DisplayIngelogdMenu);
                break;
        }
        actions[selectedOption]();

    }
}
