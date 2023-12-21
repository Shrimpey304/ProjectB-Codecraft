// namespace Restaurant;

// public class AdminEditDish
// {
//     private static string dishPath = @".\dataStorage\Dishes.json";
    

//     public static void ChangeDishName()
//     {
//         AdminFood.SeeDishes();

//         Console.WriteLine("Enter the ID of the dish you want to change:");
//         int dishID;
//         if (!int.TryParse(Console.ReadLine(), out dishID))
//         {
//             Console.WriteLine("Invalid input");
//             return;
//         }

//         List<Dish> dishes = JsonUtil.ReadFromJson<Dish>(dishPath)!;
//         Dish dishToChange = dishes.FirstOrDefault(d => d.ID == dishID)!;

//         if (dishToChange != null)
//         {
//             Console.WriteLine("Enter new dish name:");
//             string newDishName = Console.ReadLine()!;

//             dishToChange.DishName = newDishName;

//             JsonUtil.UploadToJson(dishes, dishPath);
//             Console.WriteLine("Dish name changed successfully.");
//             AdminMenu.DisplayChangeFoodMenu();
//         }
//         else
//         {
//             Console.WriteLine("Dish not found.");
//         }
//     }

//     public static void ChangeDescription()
//     {
//         AdminFood.SeeDishes();

//         Console.WriteLine("Enter the ID of the dish you want to change:");
//         int dishID;
//         if (!int.TryParse(Console.ReadLine(), out dishID))
//         {
//             Console.WriteLine("Invalid input");
//             return;
//         }

//         List<Dish> dishes = JsonUtil.ReadFromJson<Dish>(dishPath)!;
//         Dish dishToChange = dishes.FirstOrDefault(d => d.ID == dishID)!;

//         if (dishToChange != null)
//         {
//             Console.WriteLine("Enter new description:");
//             string newDescription = Console.ReadLine()!;

//             dishToChange.Description = newDescription;

//             JsonUtil.UploadToJson(dishes, dishPath);
//             Console.WriteLine("Description changed successfully.");
//             AdminMenu.DisplayChangeFoodMenu();
//         }
//         else
//         {
//             Console.WriteLine("Dish not found.");
//         }
//     }

//     public static void ChangePrice()
//     {
//         AdminFood.SeeDishes();

//         Console.WriteLine("Enter the ID of the dish you want to change:");
//         int dishID;
//         if (!int.TryParse(Console.ReadLine(), out dishID))
//         {
//             Console.WriteLine("Invalid input.");
//             return;
//         }

//         List<Dish> dishes = JsonUtil.ReadFromJson<Dish>(dishPath)!;
//         Dish dishToChange = dishes.FirstOrDefault(d => d.ID == dishID)!;

//         if (dishToChange != null)
//         {
//             Console.WriteLine("Enter the new price for dish");
//             decimal newPrice;
//             if (!decimal.TryParse(Console.ReadLine(), out newPrice))
//             {
//                 Console.WriteLine("Invalid input.");
//                 return;
//             }

//             dishToChange.Price = newPrice;

//             JsonUtil.UploadToJson(dishes, dishPath);
//             Console.WriteLine("Price changed successfully.");
//             AdminMenu.DisplayChangeFoodMenu();
//         }
//         else
//         {
//             Console.WriteLine("Dish not found.");
//         }
//     }

//     public static void ChangeAllergens()
//     {
//         AdminFood.SeeDishes();

//         Console.WriteLine("Enter the ID of the dish you want to change:");
//         int dishID;
//         if (!int.TryParse(Console.ReadLine(), out dishID))
//         {
//             Console.WriteLine("Invalid input.");
//             return;
//         }

//         List<Dish> dishes = JsonUtil.ReadFromJson<Dish>(dishPath)!;
//         Dish dishToChange = dishes.FirstOrDefault(d => d.ID == dishID)!;

//         if (dishToChange != null)
//         {
//             Console.WriteLine("Enter the new allergens");
//             string newAllergens = Console.ReadLine()!;

//             dishToChange.Allergens = newAllergens;

//             JsonUtil.UploadToJson(dishes, dishPath);
//             Console.WriteLine("Allergens changed successfully.");
//             AdminMenu.DisplayChangeFoodMenu();
//         }
//         else
//         {
//             Console.WriteLine("Dish not found.");
//         }
//     }

//     public static void ChangeDishType()
//     {
//         AdminFood.SeeDishes();

//         Console.WriteLine("Enter the ID of the dish you want to change:");
//         int dishID;
//         if (!int.TryParse(Console.ReadLine(), out dishID))
//         {
//             Console.WriteLine("Invalid input");
//             return;
//         }

//         List<Dish> dishes = JsonUtil.ReadFromJson<Dish>(dishPath)!;
//         Dish dishToChange = dishes.FirstOrDefault(d => d.ID == dishID)!;

//         if (dishToChange != null)
//         {
//             Console.WriteLine("Enter the new dish type for dish");
//             string newDishType = Console.ReadLine()!;

//             dishToChange.DishType = newDishType;

//             JsonUtil.UploadToJson(dishes, dishPath);
//             Console.WriteLine("Dish type changed successfully.");
//             AdminMenu.DisplayChangeFoodMenu();
//         }
//         else
//         {
//             Console.WriteLine("Dish not found.");
//         }
//     }
// }