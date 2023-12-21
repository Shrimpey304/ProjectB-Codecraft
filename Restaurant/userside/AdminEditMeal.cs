// namespace Restaurant
// {
//     public class AdminEditMeal
//     {
//         private static string mealsPath = @".\dataStorage\Meals.json";

//         public static void ChangeCourseType()
//         {
//             AdminFood.SeeMeals();

//             Console.WriteLine("Enter the ID of the meal you want to change:");
//             int mealID;
//             if (!int.TryParse(Console.ReadLine(), out mealID))
//             {
//                 Console.WriteLine("Invalid input");
//                 return;
//             }

//             List<Meals> meals = JsonUtil.ReadFromJson<Meals>(mealsPath);
//             Meals mealToChange = meals.FirstOrDefault(m => m.ID == mealID);

//             if (mealToChange != null)
//             {
//                 Console.WriteLine("Enter new course type:");
//                 int newCourseType;
//                 if (!int.TryParse(Console.ReadLine(), out newCourseType))
//                 {
//                     Console.WriteLine("Invalid input");
//                     return;
//                 }

//                 mealToChange.CourseType = newCourseType;

//                 JsonUtil.UploadToJson(meals, mealsPath);
//                 Console.WriteLine("Course type changed successfully.");
//                 AdminMenu.DisplayChangeFoodMenu();
//             }
//             else
//             {
//                 Console.WriteLine("Meal not found.");
//             }
//         }

//         public static void ChangeMealType()
//         {
//             AdminFood.SeeMeals();

//             Console.WriteLine("Enter the ID of the meal you want to change:");
//             int mealID;
//             if (!int.TryParse(Console.ReadLine(), out mealID))
//             {
//                 Console.WriteLine("Invalid input");
//                 return;
//             }

//             List<Meals> meals = JsonUtil.ReadFromJson<Meals>(mealsPath);
//             Meals mealToChange = meals.FirstOrDefault(m => m.ID == mealID);

//             if (mealToChange != null)
//             {
//                 Console.WriteLine("Enter new meal type:");
//                 string newMealType = Console.ReadLine();

//                 mealToChange.MealType = newMealType;

//                 JsonUtil.UploadToJson(meals, mealsPath);
//                 Console.WriteLine("Meal type changed successfully.");
//                 AdminMenu.DisplayChangeFoodMenu();
//             }
//             else
//             {
//                 Console.WriteLine("Meal not found.");
//             }
//         }

//         public static void ChangeMealName()
//         {
//             AdminFood.SeeMeals();

//             Console.WriteLine("Enter the ID of the meal you want to change:");
//             int mealID;
//             if (!int.TryParse(Console.ReadLine(), out mealID))
//             {
//                 Console.WriteLine("Invalid input");
//                 return;
//             }

//             List<Meals> meals = JsonUtil.ReadFromJson<Meals>(mealsPath);
//             Meals mealToChange = meals.FirstOrDefault(m => m.ID == mealID);

//             if (mealToChange != null)
//             {
//                 Console.WriteLine("Enter new meal name:");
//                 string newMealName = Console.ReadLine();

//                 mealToChange.MealName = newMealName;

//                 JsonUtil.UploadToJson(meals, mealsPath);
//                 Console.WriteLine("Meal name changed successfully.");
//                 AdminMenu.DisplayChangeFoodMenu();
//             }
//             else
//             {
//                 Console.WriteLine("Meal not found.");
//             }
//         }

//         public static void ChangePrice()
//         {
//             AdminFood.SeeMeals();

//             Console.WriteLine("Enter the ID of the meal you want to change:");
//             int mealID;
//             if (!int.TryParse(Console.ReadLine(), out mealID))
//             {
//                 Console.WriteLine("Invalid input.");
//                 return;
//             }

//             List<Meals> meals = JsonUtil.ReadFromJson<Meals>(mealsPath);
//             Meals mealToChange = meals.FirstOrDefault(m => m.ID == mealID);

//             if (mealToChange != null)
//             {
//                 Console.WriteLine("Enter the new price for meal");
//                 decimal newPrice;
//                 if (!decimal.TryParse(Console.ReadLine(), out newPrice))
//                 {
//                     Console.WriteLine("Invalid input.");
//                     return;
//                 }

//                 mealToChange.Price = newPrice;

//                 JsonUtil.UploadToJson(meals, mealsPath);
//                 Console.WriteLine("Price changed successfully.");
//                 AdminMenu.DisplayChangeFoodMenu();
//             }
//             else
//             {
//                 Console.WriteLine("Meal not found.");
//             }
//         }

//         public static void ChangeCourseDescription()
//         {
//             AdminFood.SeeMeals();

//             Console.WriteLine("Enter the ID of the meal you want to change:");
//             int mealID;
//             if (!int.TryParse(Console.ReadLine(), out mealID))
//             {
//                 Console.WriteLine("Invalid input.");
//                 return;
//             }

//             List<Meals> meals = JsonUtil.ReadFromJson<Meals>(mealsPath);
//             Meals mealToChange = meals.FirstOrDefault(m => m.ID == mealID);

//             if (mealToChange != null)
//             {
//                 Console.WriteLine("Enter new course description:");
//                 string newDescription = Console.ReadLine();

//                 mealToChange.CourseDescription = newDescription;

//                 JsonUtil.UploadToJson(meals, mealsPath);
//                 Console.WriteLine("Course description changed successfully.");
//                 AdminMenu.DisplayChangeFoodMenu();
//             }
//             else
//             {
//                 Console.WriteLine("Meal not found.");
//             }
//         }
//     }
// }
