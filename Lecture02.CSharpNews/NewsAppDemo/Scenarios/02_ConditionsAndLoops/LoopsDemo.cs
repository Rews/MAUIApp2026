namespace CourseLecture02;

// 02. Условие выбирает действие, цикл повторяет действия.
// Сравните цикл со счётчиком for и перебор элементов foreach.

internal static class LoopsDemo
{
    public static void Run()
    {
        string title = "УрФУ: библиотека";
        // if выполняет блок только при истинном условии.
        if (title.Length > 0)
        {
            Console.WriteLine(title);
        }

        // Начальное значение; условие продолжения; изменение счётчика.
        // number++ увеличивает счётчик на 1 после тела цикла.
        // Условие <= 3 включает число 3: тело выполнится три раза.
        for (int number = 1; number <= 3; number++)
        {
            Console.WriteLine($"Новость {number}");
        }

        // Массив содержит два заголовка. Его длина задаётся при создании.
        string[] titles = { "Библиотека", "Лаборатория" };
        // foreach получает очередной элемент: вручную вычислять индекс не нужно.
        // item — текущая строка массива; на следующем шаге цикл возьмёт следующую.
        foreach (var item in titles)
        {
            Console.WriteLine(item);
        }
    }
}
