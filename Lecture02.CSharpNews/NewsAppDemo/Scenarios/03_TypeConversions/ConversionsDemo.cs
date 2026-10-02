namespace CourseLecture02;

// 03. Преобразования: числовое приведение, разбор текста и проверка переполнения.
// Обратите внимание: приведение double к int не округляет до ближайшего целого.

internal static class ConversionsDemo
{
    public static void Run()
    {
        int newsCount = 3;
        // Неявное преобразование int → double: явное указание типа в скобках не нужно.
        double countAsDouble = newsCount;
        double readingMinutes = 2.8;
        // Явное приведение отбрасывает дробную часть в сторону нуля: 2.8 → 2, -2.8 → -2.
        int wholeMinutes = (int)readingMinutes;

        // Строка с цифрами — ещё не число. TryParse возвращает успех через bool,
        // а числовой результат — через параметр out.
        bool parsed = int.TryParse("12", out int limit);
        Console.WriteLine($"(int)2.8: {wholeMinutes}");
        Console.WriteLine($"(int)-2.8: {(int)-2.8}");
        Console.WriteLine(limit);
        Console.WriteLine($"Количество как double: {countAsDouble}");
        Console.WriteLine($"TryParse для 12: {parsed}");

        // Некорректный ввод не вызывает исключение: получим false и 0 в invalidLimit.
        // Использовать результат как введённое число можно только при успешном разборе.
        bool invalidParsed = int.TryParse("двенадцать", out int invalidLimit);
        Console.WriteLine($"TryParse для текста: {invalidParsed}, результат: {invalidLimit}");
        try
        {
            double tooLarge = (double)int.MaxValue + 1;
            // checked требует проверки диапазона: число больше int.MaxValue вызовет OverflowException.
            int impossible = checked((int)tooLarge);
            Console.WriteLine(impossible);
        }
        // Перехватываем ожидаемую ошибку, чтобы демонстрация продолжилась.
        catch (OverflowException)
        {
            Console.WriteLine("checked: число вне диапазона int");
        }
    }
}
