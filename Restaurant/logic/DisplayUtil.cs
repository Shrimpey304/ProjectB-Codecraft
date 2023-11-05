namespace Restaurant;
/*
plss use this. it makes life so much eaier.
just give it a list of the options you'll have in your menu and it'll do the rest
*/
public static class DisplayUtil
{
    public static int Display(List<string> options)
    {
        Console.Clear();
        Console.CursorVisible = false;
        (int left, int top) = Console.GetCursorPosition();
        int selectedOption = 0;
        string decorator = "[x]\u001b[32m";
        ConsoleKeyInfo key;
        bool isSelected = false;
        
        while (!isSelected)
        {
            Console.SetCursorPosition(left, top);

            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{(selectedOption == i ? decorator : "[ ]")}{options[i]}\u001b[34m");
            }

            key = Console.ReadKey(false);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedOption = selectedOption == 0 ? options.Count - 1 : selectedOption - 1;
                    break;

                case ConsoleKey.DownArrow:
                    selectedOption = selectedOption == options.Count - 1 ? 0 : selectedOption + 1;
                    break;

                case ConsoleKey.Enter:
                    isSelected = true;
                    break;

                // case ConsoleKey.Escape:
                //     selectedOption = options.Count - 1;
                //     isSelected = true;
                //     break;
            }
        }
        return selectedOption;
    }
}
