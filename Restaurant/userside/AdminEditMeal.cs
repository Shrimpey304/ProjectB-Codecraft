namespace Restaurant
{
    public class AdminEditMeal
    {
        private static string mealsPath = @".\dataStorage\Meals.json";
        private static List<Meals> meals = JsonUtil.ReadFromJson<Meals>(mealsPath);

        private static Meals GetMealById(User user)
        {
            Console.WriteLine("Enter the ID of the meal you want to change:");
            int mealID;
            if (!int.TryParse(Console.ReadLine(), out mealID))
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine("Heading back to admin menu");
                Thread.Sleep(2000);
                AdminMenu.DisplayAdminMenu(user);
                return null;
            }

            Meals mealToChange = meals.FirstOrDefault(m => m.ID == mealID);

            if (mealToChange == null)
            {
                Console.WriteLine("Meal not found.");
                Console.WriteLine("Heading back to admin menu");
                Thread.Sleep(2000);
                AdminMenu.DisplayAdminMenu(user);
            }

            return mealToChange;
        }

        public static void ChangeCourseType(User user)
        {
            FormatJsonJ.FormatMeals();
            Meals mealToChange = GetMealById(user);

            if (mealToChange != null)
            {
                Console.WriteLine("Enter new course type:");
                int newCourseType;
                if (!int.TryParse(Console.ReadLine(), out newCourseType))
                {
                    Console.WriteLine("Invalid input");
                    Console.WriteLine("Heading back to admin menu");
                    Thread.Sleep(2000);
                    AdminMenu.DisplayAdminMenu(user);
                    return;
                }

                mealToChange.CourseType = newCourseType;

                JsonUtil.UploadToJson(meals, mealsPath);
                Console.WriteLine("Course type changed successfully.");
                Thread.Sleep(2000);
                AdminMenu.DisplayChangeFoodMenu(user);
            }
        }

        public static void ChangeMealType(User user)
        {
            FormatJsonJ.FormatMeals();
            Meals mealToChange = GetMealById(user);

            if (mealToChange != null)
            {
                Console.WriteLine("Enter new meal type:");
                string newMealType = Console.ReadLine();

                mealToChange.MealType = newMealType;

                JsonUtil.UploadToJson(meals, mealsPath);
                Console.WriteLine("Meal type changed successfully.");
                Thread.Sleep(2000);
                AdminMenu.DisplayChangeFoodMenu(user);
            }
            else
            {
                Console.WriteLine("Meal not found.");
                Console.WriteLine("Heading back to admin menu");
                Thread.Sleep(2000);
                AdminMenu.DisplayAdminMenu(user);
            }
        }

        public static void ChangeMealName(User user)
        {
            FormatJsonJ.FormatMeals();
            Meals mealToChange = GetMealById(user);

            if (mealToChange != null)
            {
                Console.WriteLine("Enter new meal name:");
                string newMealName = Console.ReadLine();

                mealToChange.MealName = newMealName;

                JsonUtil.UploadToJson(meals, mealsPath);
                Console.WriteLine("Meal name changed successfully.");
                Thread.Sleep(2000);
                AdminMenu.DisplayChangeFoodMenu(user);
            }
            else
            {
                Console.WriteLine("Meal not found.");
                Console.WriteLine("Heading back to admin menu");
                Thread.Sleep(2000);
                AdminMenu.DisplayAdminMenu(user);
            }
        }

        public static void ChangePrice(User user)
        {
            FormatJsonJ.FormatMeals();
            Meals mealToChange = GetMealById(user);

            if (mealToChange != null)
            {
                Console.WriteLine("Enter the new price for meal");
                decimal newPrice;
                if (!decimal.TryParse(Console.ReadLine(), out newPrice))
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Heading back to admin menu");
                    Thread.Sleep(2000);
                    AdminMenu.DisplayAdminMenu(user);
                    return;
                }

                mealToChange.Price = newPrice;

                JsonUtil.UploadToJson(meals, mealsPath);
                Console.WriteLine("Price changed successfully.");
                Thread.Sleep(2000);
                AdminMenu.DisplayChangeFoodMenu(user);
            }
            else
            {
                Console.WriteLine("Meal not found.");
                Console.WriteLine("Heading back to admin menu");
                Thread.Sleep(2000);
                AdminMenu.DisplayAdminMenu(user);
            }
        }

        public static void ChangeCourseDescription(User user)
        {
            FormatJsonJ.FormatMeals();
            Meals mealToChange = GetMealById(user);

            if (mealToChange != null)
            {
                Console.WriteLine("Enter new course description:");
                string newDescription = Console.ReadLine();

                mealToChange.CourseDescription = newDescription;

                JsonUtil.UploadToJson(meals, mealsPath);
                Console.WriteLine("Course description changed successfully.");
                Thread.Sleep(2000);
                AdminMenu.DisplayChangeFoodMenu(user);
            }
            else
            {
                Console.WriteLine("Meal not found.");
                Console.WriteLine("Heading back to admin menu");
                Thread.Sleep(2000);
                AdminMenu.DisplayAdminMenu(user);
            }
        }
    }
}
