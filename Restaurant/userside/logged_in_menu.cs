namespace Restaurant;

public class Ingelogdmenu
{
    public User? user;
    public List<MasterLogin>? logOut = new();
    Login login = new();
    public void DisplayIngelogdMenu()
    {
        MakeReservation makeReservation = new(user);
        MenuCard menuCard = new();
        //PersonalInfoTest personalProcess = new();
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
                menuCard.windowInstanceStack.Add(DisplayIngelogdMenu);
                menuCard.user = user;
                menuCard.FromMain(false);
                break;
            case 1:
                RestaurantInfo.DisplayRestaurantInfo(user);
                break;
            case 2:
                makeReservation.windowInstance.Add(this);
                makeReservation.Display();
                break;
            case 3:
                orderHistory.windowInstance.Add(this);
                if(user == null){throw new Exception("user is null");}
                if (user != null) //added null check
                {
                    orderHistory.DisplayOrderHistory(user); // user is niet set to instance
                }
                break;
            case 4:
                UserChangeOwnAcc.SeeAccInfoByPassword(user);
                break;
            case 5:
                //if (this.logOut.Count == 0){throw new Exception("list = 0 :(");}
                login.LogOut();
                MainMenu.DisplayMainMenu();
                break;
        }
    }

    public void FromMR(List<MasterLogin> logout){
        logOut = logout;
        
        this.DisplayIngelogdMenu();
    }
}
