namespace CourseLecture02;

// 01. Типы и переменные: сравните явно заданный тип с выводом типа через var.
// Run вызывается из Program; static позволяет вызвать метод без new BasicsDemo().

internal static class BasicsDemo
{
    public static void Run()
    {
        // string хранит текст, int — целое число, bool — true или false.
        // Объявление переменной задаёт тип, имя и начальное значение.
        string title = "УрФУ: библиотека";
        string imageUrl = "https://example.org/1.jpg";
        int previewLength = 12;
        // Проверяем наличие строки с адресом; сетевого запроса здесь нет.
        bool hasImage = imageUrl.Length > 0;
        
        // var выводит тип Int32 из Length, но тип переменной остаётся статическим.
        var titleLength = title.Length;
        // Сокращение для previewLength = previewLength + 3: теперь лимит равен 15.
        previewLength += 3;
        // titleLength = "много"; // Ошибка компиляции: здесь ожидается int.

        Console.WriteLine(title);
        // Интерполяция $"...{выражение}..." вставляет значение в текст сообщения.
        Console.WriteLine($"Длина заголовка: {titleLength}");
        Console.WriteLine($"Лимит анонса: {previewLength}");
        Console.WriteLine($"Есть адрес картинки: {hasImage}");
    }
}
