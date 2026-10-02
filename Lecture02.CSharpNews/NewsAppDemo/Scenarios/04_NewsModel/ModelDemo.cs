namespace CourseLecture02;

// 04. Работа с объектом: чтение свойств и вызов методов модели.
// Откройте NewsArticle и сопоставьте каждое действие с его реализацией.

internal static class ModelDemo
{
    public static void Run()
    {
        // Фабрика создаёт NewsArticle через new. var здесь означает тип NewsArticle.
        var article = DemoData.CreateArticle();
        Console.WriteLine(article.Title);
        // Метод проверит заголовок и уберёт пробелы. Снаружи не нужно повторять эти правила.
        article.RenameTitle("  Новый зал  ");
        Console.WriteLine(article.Title);
        // Именованный аргумент maxLength поясняет смысл числа 12.
        Console.WriteLine(article.GetPreview(maxLength: 12));
        // Лимит больше текста: модель вернёт весь текст, не дополнит его и не выдаст ошибку.
        Console.WriteLine(article.GetPreview(100));
        // Получение анонса не обрезало Text внутри новости: метод вернул отдельную строку.
        Console.WriteLine($"Полный текст: {article.Text}");
        // article.Title = ""; // private set: изменять заголовок нужно через метод.
    }
}
