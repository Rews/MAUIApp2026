namespace CourseLecture02;

// 15. Защита модели: ошибочный вызов даёт исключение, корректный продолжает работать.
// Ошибки создаём намеренно, чтобы увидеть переход из try в соответствующий catch.

internal static class ErrorsDemo
{
    public static void Run()
    {
        var article = DemoData.CreateArticle();
        try
        {
            // GetPreview выбросит исключение до возврата строки, поэтому WriteLine не вызовется.
            Console.WriteLine(article.GetPreview(0));
        }
        // Перехватываем ошибку диапазона параметра и объясняем её пользователю.
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Проверьте длину");
        }
        // После catch продолжаем выполнение. Предыдущая ошибка не повредила объект.
        Console.WriteLine($"Корректный анонс: {article.GetPreview(12)}");
        try
        {
            // Проверка заголовка выполняется до присваивания Title, поэтому старое значение сохранится.
            article.RenameTitle("   ");
        }
        // Для пустого заголовка модель использует другой тип исключения — ArgumentException.
        catch (ArgumentException)
        {
            Console.WriteLine("Нужен непустой заголовок");
        }
        // Проверяем не только сообщение об ошибке, но и состояние объекта после неё.
        Console.WriteLine($"Заголовок сохранён: {article.Title}");
    }
}
