class Program
{
    static void Main()
    {
        var (name, surname, age, hasPet, petCount, petNames, colorCount, colors) = GetUserData();
        PrintUserData(name, surname, age, hasPet, petCount, petNames, colorCount, colors);
    }

    static (string, string, int, bool, int, string[], int, string[]) GetUserData()
    {
        Console.Write("Введите имя: ");
        string name = Console.ReadLine();

        Console.Write("Введите фамилию: ");
        string surname = Console.ReadLine();

        int age = GetValidInt("Введите возраст: ");

        bool hasPet = GetYesNo("Есть ли у Вас питомец? (да/нет) ");

        int petCount = 0;
        string[] petNames = null;
        if (hasPet)
        {
            petCount = GetValidInt("Введите количество питомцев: ");
            petNames = GetPetNames(petCount);
        }

        int colorCount = GetValidInt("Введите количество любимых цветов: ");
        string[] colors = GetColors(colorCount);

        return (name, surname, age, hasPet, petCount, petNames, colorCount, colors);
    }

    static int GetValidInt(string prompt)
    {
        int value;
        while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
        {
            Console.WriteLine("Некорректный ввод. Введите положительное число.");
            Console.Write(prompt);
        }
        return value;
    }

    static bool GetYesNo(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine().ToLower();
        } while (input != "да" && input != "нет");
        return input == "да";
    }

    static string[] GetPetNames(int count)
    {
        string[] names = new string[count];
        for (int i = 0; i < count; i++)
        {
            Console.Write($"Введите кличку питомца {i + 1}: ");
            names[i] = Console.ReadLine();
        }
        return names;
    }

    static string[] GetColors(int count)
    {
        string[] colors = new string[count];
        for (int i = 0; i < count; i++)
        {
            Console.Write($"Введите любимый цвет {i + 1}: ");
            colors[i] = Console.ReadLine();
        }
        return colors;
    }

    static void PrintUserData(string name, string surname, int age, bool hasPet, int petCount, string[] petNames, int colorCount, string[] colors)
    {
        Console.WriteLine($"Имя: {name}");
        Console.WriteLine($"Фамилия: {surname}");
        Console.WriteLine($"Возраст: {age}");
        Console.WriteLine($"Есть питомец: {(hasPet ? "Да" : "Нет")}");
        if (hasPet)
        {
            Console.WriteLine($"Количество питомцев: {petCount}");
            Console.WriteLine("Клички питомцев:");
            foreach (var petName in petNames)
            {
                Console.WriteLine($"- {petName}");
            }
        }
        Console.WriteLine($"Количество любимых цветов: {colorCount}");
        Console.WriteLine("Любимые цвета:");
        foreach (var color in colors)
        {
            Console.WriteLine($"- {color}");
        }
    }
}
