namespace CourseLecture02;

// 11. Task без <T> сообщает о завершении операции, но не содержит возвращаемого значения.
// Показываем успешное завершение и обработку ошибки при await.

internal static class AsyncOperationDemo
{
    public static async Task RunAsync()
    {
        // Вызовы последовательны: сначала дожидаемся успеха, затем запускаем пример ошибки.
        // Именованный аргумент поясняет, какой случай включён.
        
        try
        {
            await ShowRefreshAsync(simulateError: false);
            await ShowRefreshAsync(simulateError: true);
            Console.WriteLine("Программа продолжает работу");
        }
        catch
        {
            Console.WriteLine("Программа сломалась");
        }
    }

    private static async Task ShowRefreshAsync(bool simulateError)
    {
        Console.WriteLine(simulateError ? "Сценарий ошибки:" : "Сценарий успеха:");
        // Сохраняем Task, чтобы после ожидания посмотреть его состояние.
        Task refreshing = RefreshAsync(simulateError);
        try
        {
            // await проверяет результат операции. При ошибке выбросит её исключение,
            // а следующие строки try не выполнятся — управление перейдёт в catch.
            await refreshing;
            Console.WriteLine("Обновление завершено");
            Console.WriteLine($"Успешно завершена: {refreshing.IsCompletedSuccessfully}");
        }
        // Обрабатываем конкретную ожидаемую ошибку; exception.Message содержит пояснение.
        // Task останется в состоянии ошибки, даже если вызывающий код обработал исключение.
        catch (InvalidOperationException exception)
        {
            Console.WriteLine($"Не удалось обновить: {exception.Message}");
            Console.WriteLine($"Завершена с ошибкой: {refreshing.IsFaulted}");
            throw;
        }
        catch (NullReferenceException exception)
        {
            Console.WriteLine($"Не удалось обновить: {exception.Message}");
        }
        catch (Exception ex)
        {
             Console.WriteLine($"Не удалось обновить: {ex.Message}");
        }
    }

    private static async Task RefreshAsync(bool simulateError)
    {
        await Task.Delay(100);
        if (simulateError)
        {
            // Исключение после ожидания завершает Task с ошибкой; вызывающий await её наблюдает.
            throw new InvalidOperationException("источник временно недоступен");
        }
        // Это имитация завершения операции: файлы и сеть не используются.
    }
}
