namespace CourseLecture02;

// Пульт запуска демо: здесь выбираем пример, а его учебный код читаем
// в соответствующей папке Scenarios/01–15.

internal static class Program
{
    // Порядок названий совпадает с номерами папок и ветками switch ниже.
    // Индекс массива начинается с 0, а номер сценария для пользователя — с 1.
    private static readonly string[] ScenarioNames =
    [
        "Точка входа, типы и переменные",
        "Условия и циклы",
        "Преобразования типов",
        "Модель новости",
        "Ссылки и null",
        "Наследование",
        "Проверки типов: is и as",
        "Делегаты: Action и Func",
        "События",
        "Task и await: результат",
        "Task: успех и ошибка",
        "Коллекции и LINQ",
        "Лента новостей",
        "Ввод длины анонса",
        "Ошибки модели",
    ];

    // Точка входа приложения. Task позволяет использовать await в Main
    // и дождаться завершения асинхронного сценария перед следующим выбором.
    private static async Task Main()
    {
        // Полный список печатаем один раз, до цикла. Вывод сценариев остаётся в консоли.
        ShowMenu();
        // Повторяем выбор, пока пользователь не введёт 0 или не закончится поток ввода.
        while (true)
        {
            Console.Write("Номер сценария: ");
            // ReadLine возвращает строку, а при конце входного потока — null.
            // Пустая строка после Enter и null — разные случаи.
            string? input = Console.ReadLine();
            if (input is null)
                return;

            // TryParse проверяет запись числа и помещает результат в number через out.
            // || читается как «или»: достаточно ошибки преобразования либо выхода за диапазон.
            if (!int.TryParse(input, out int number) || number < 0 || number > ScenarioNames.Length)
            {
                Console.WriteLine("Введите номер от 1 до 15 или 0 для выхода.");
                // continue начинает следующую итерацию: снова спрашиваем номер, без списка.
                continue;
            }

            // return завершает Main и приложение; break ниже завершает только switch.
            if (number == 0)
            {
                Console.WriteLine("До встречи!");
                return;
            }

            Console.WriteLine();
            // Формат 00 добавляет ведущий ноль, например 01. number - 1 даёт индекс названия.
            Console.WriteLine($"=== {number:00}. {ScenarioNames[number - 1]} ===");
            // Каждая ветка вызывает один пример. Run — обычный метод;
            // RunAsync возвращает Task, поэтому для сценариев 10, 11 и 13 нужен await.
            switch (number)
            {
                case 1:
                    BasicsDemo.Run();
                    break;
                case 2:
                    LoopsDemo.Run();
                    break;
                case 3:
                    ConversionsDemo.Run();
                    break;
                case 4:
                    ModelDemo.Run();
                    break;
                case 5:
                    ReferencesDemo.Run();
                    break;
                case 6:
                    InheritanceDemo.Run();
                    break;
                case 7:
                    TypeChecksDemo.Run();
                    break;
                case 8:
                    DelegatesDemo.Run();
                    break;
                case 9:
                    EventsDemo.Run();
                    break;
                case 10:
                    await AsyncResultDemo.RunAsync();
                    break;
                case 11:
                    await AsyncOperationDemo.RunAsync();
                    break;
                case 12:
                    CollectionsDemo.Run();
                    break;
                case 13:
                    await NewsFeedDemo.RunAsync();
                    break;
                case 14:
                    InputDemo.Run();
                    break;
                case 15:
                    ErrorsDemo.Run();
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Сценарий завершён. Можно выбрать следующий.");
        }
    }

    // Отдельный метод отвечает только за печать списка; ввод и проверка остаются в Main.
    private static void ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Лекция 2. Выберите сценарий:");
        for (int i = 0; i < ScenarioNames.Length; i++)
            Console.WriteLine($"{i + 1:00}. {ScenarioNames[i]}");
        Console.WriteLine("00. Выход");
    }
}
