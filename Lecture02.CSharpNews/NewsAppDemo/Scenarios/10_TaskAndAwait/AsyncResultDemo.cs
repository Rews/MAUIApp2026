namespace CourseLecture02;

// 10. Task<T> представляет операцию с результатом, await позволяет получить этот результат.
// Проследите порядок сообщений 1 → 2 → 3 → 4: async не означает «сразу в другом потоке».

internal static class AsyncResultDemo
{
    public static async Task RunAsync()
    {
        Console.WriteLine("1. Вызываем загрузку");
        // Метод начинает выполняться сразу и дойдёт до первого незавершённого await.
        // В loading сохраняется Task<string>, а не готовый заголовок.
        Task<string> loading = LoadTitleAsync();
        Console.WriteLine("3. Вызов вернул Task<string>");
        // Если операция ещё не завершена, этот метод приостановится.
        // После успешного завершения await даст string, и выполнение продолжится ниже.
        string title = await loading;
        Console.WriteLine($"4. Получен результат: {title}");
        // После успешного await эта проверка даст true: результат уже получен.
        Console.WriteLine($"Успешно завершена: {loading.IsCompletedSuccessfully}");
    }

    private static async Task<string> LoadTitleAsync()
    {
        Console.WriteLine("2. Метод начал работу");
        // Задержка имитирует ожидание данных без сетевого запроса и блокирующего Thread.Sleep.
        await Task.Delay(5000);
        // async-метод возвращает строку как результат операции Task<string>.
        return "УрФУ: библиотека";
    }
}
