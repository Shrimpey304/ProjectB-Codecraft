// namespace Restaurant;

// public class AdminMenu
// {
//     public static void DisplayAdminMenu()
//     {
//         List<string> options = new(){
//             "Change accounts",
//             "Change food menu",
//             "Change reservations",
//             "Change tables",
//             "Change application colors",
//             "Quit Application"
//         };
//         List<Action> actions = new(){
//             DisplayChangeAccMenu,
//             DisplayChangeFoodMenu,
//             DisplayChangeResvMenu,
//             DisplayChangeTableMenu,
//             DisplayChangeColorMenu,
//             Quit
//         };
//         int selectedOption = DisplayUtil.Display(options);
//         actions[selectedOption]();
//     }

//     public static void DisplayChangeAccMenu()
//     {
//         List<string> options = new(){
//             "See accounts",
//             "Add account",
//             "Remove account",
//             "Change account",
//             "Go back to admin menu"
//         };
//         List<Action> actions = new(){
//             AdminAccounts.SeeAccountsB,
//             AdminAccounts.AddAccountsA,
//             AdminAccounts.RemoveAccountsA,
//             ChangeAccountsA,
//             DisplayAdminMenu
//         };
//         int selectedOption = DisplayUtil.Display(options);
//         actions[selectedOption]();
//     }

//     public static void DisplayChangeFoodMenu()
//     {
//         MenuCard menuCard = new MenuCard();
//         List<string> options = new(){
//             "See dishes",
//             "Add dish",
//             "Add meal",
//             "Remove dish",
//             "Remove meal",
//             "Change dish",
//             "Change meal",
//             "Remove all dishes",
//             "Go back to admin menu"
//         };
//         List<Action> actions = new(){
//             AdminFood.SeeDishesB,
//             AdminFood.AddDishA,
//             AdminFood.AddMealA,
//             AdminFood.RemoveDishA,
//             AdminFood.RemoveMealA,
//             ChangeDishA,
//             ChangeMealA,
//             AdminFood.RemAllDishes,
//             DisplayAdminMenu
//         };
//         int selectedOption = DisplayUtil.Display(options);
//         actions[selectedOption]();
//     }

//     public static void DisplayChangeResvMenu()
//     {
//         MakeReservation makeReservation = new MakeReservation();
//         List<string> options = new(){
//             "See reservations",
//             "Add reservation",
//             "Remove reservation",
//             "Change reservation",
//             "Go back to admin menu"
//         };
//         List<Action> actions = new(){
//             AdminReservations.SeeReservationsA,
//             makeReservation.MakeReserve,
//             AdminReservations.RemovReservationA,
//             AdminReservations.ChangeReservationA,
//             DisplayAdminMenu
//         };
//         int selectedOption = DisplayUtil.Display(options);
//         actions[selectedOption]();
//     }

//     public static void DisplayChangeTableMenu()
//     {
//         List<string> options = new(){
//             "See tables",
//             "Add table",
//             "Remove table",
//             "Change table",
//             "Go back to admin menu"
//         };
//         List<Action> actions = new(){
//             AdminTable.SeeTablesA,
//             AdminTable.AddTableA,
//             AdminTable.RemoveTableA,
//             AdminTable.ChangeTableA,
//             DisplayAdminMenu
//         };
//         int selectedOption = DisplayUtil.Display(options);
//         actions[selectedOption]();
//     }

//     public static void DisplayChangeColorMenu()
//     {
//         List<string> options = new(){
//             "Set color",
//             "Change color",
//             "Go back to admin menu"
//         };
//         List<Action> actions = new(){
//             AdminColor.SetColor,
//             AdminColor.ChangeColor,
//             DisplayAdminMenu
//         };
//         int selectedOption = DisplayUtil.Display(options);
//         actions[selectedOption]();
//     }


//     private static void Quit()
//     {
//         Console.WriteLine("Quitting application...");
//         return;
//     }

//     public static void ChangeAccountsA()
//     {   
//         List<string> options = new(){
//             "Change email of account",
//             "Change password of account",
//             "Change phone number of account",
//             "Change admin status of account",
//             "Go back to admin accounts menu"
//         };
//         List<Action> actions = new(){
//             AdminEditAccs.ChangeEmail,
//             AdminEditAccs.ChangePassword,
//             AdminEditAccs.ChangePhonenumber,
//             AdminEditAccs.ChangeAdminstatus,
//             DisplayChangeAccMenu,
//         };
//         int selectedOption = DisplayUtil.Display(options);
//         actions[selectedOption]();
        

//     }

//     public static void ChangeDishA()
//     {   
//         List<string> options = new(){
//             "Change name of dish",
//             "Change type of dish",
//             "Change description of dish",
//             "Change price of dish",
//             "Change allergiens of dish",
//             "Go back to admin accounts menu"
//         };
//         List<Action> actions = new(){
//             AdminEditDish.ChangeDishName,
//             AdminEditDish.ChangeDishType,
//             AdminEditDish.ChangeDescription,
//             AdminEditDish.ChangePrice,
//             AdminEditDish.ChangeAllergens,
//             DisplayChangeAccMenu,
//         };
//         int selectedOption = DisplayUtil.Display(options);
//         actions[selectedOption]();
        

//     }

//     public static void ChangeMealA()
//     {   
//         List<string> options = new(){
//             "Change course type",
//             "Change meal type",
//             "Change name of meal",
//             "Change price of meal",
//             "Change description of meal",
//             "Go back to admin accounts menu"
//         };
//         List<Action> actions = new(){
//             AdminEditMeal.ChangeCourseType,
//             AdminEditMeal.ChangeMealType,
//             AdminEditMeal.ChangeMealName,
//             AdminEditMeal.ChangePrice,
//             AdminEditMeal.ChangeCourseDescription,
//             DisplayChangeAccMenu,
//         };
//         int selectedOption = DisplayUtil.Display(options);
//         actions[selectedOption]();
        

//     }
// }