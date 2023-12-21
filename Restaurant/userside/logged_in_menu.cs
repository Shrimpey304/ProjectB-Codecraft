namespace Restaurant;

public class Ingelogdmenu
{
    public User user;
    public List<MasterLogin>? logOut = new();
    public void DisplayIngelogdMenu()
    {
        MakeReservation makeReservation = new(user);
        MenuCard menuCard = new();
        PersonalInfoTest personalProcess = new();
        OrderHistoryTest orderHistory = new();
        List<string> LogedInMenuOptions = new(){
            "Menu (food)",
            "Restaurant informatie",
            "Make reservation",
            "Reservation history",
            "Personal information",
            "Logout"
        };
        int selectedOption = DisplayUtil.Display(LogedInMenuOptions);
        switch (selectedOption)
        {
            case 0:
                menuCard.windowInstanceStack.Push(DisplayIngelogdMenu);
                menuCard.FromMain(user);
                break;
            case 1:
                RestaurantInfoTest.DisplayRestaurantInfo();
                break;
            case 2:
                makeReservation.windowInstance.Add(this);
                makeReservation.Display();
                break;
            case 3:
                orderHistory.windowInstance.Add(this);
                orderHistory.DisplayOrderHistory(user);
                break;
            case 4:
                personalProcess.windowInstance.Add(this);
                personalProcess.DisplayPersonalInfo(user);
                break;
            case 5:
                //if (this.logOut.Count == 0){throw new Exception("list = 0 :(");}
                MasterLogin lout = logOut[0];
                lout.LogOut(user);
                MainMenu.DisplayMainMenu();
                break;
        }
    }

    public void FromMR(List<MasterLogin> logout){
        logOut = logout;
        
        this.DisplayIngelogdMenu();
    }
}
