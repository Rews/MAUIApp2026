namespace CourseLecture02;

// 06. Наследование и полиморфизм: тип переменной и фактический тип объекта могут различаться.

internal static class InheritanceDemo
{
    public static void Run()
    {
        var videoArticle = DemoData.CreateVideoArticle();
        // Производный тип можно неявно присвоить переменной базового типа.
        // Объект остаётся видеоновостью; новый экземпляр NewsArticle не создаётся.
        NewsArticle article = videoArticle;
        Console.WriteLine(article.Title);
        // Унаследованный метод меняет общий объект, что видно через обе переменные.
        article.RenameTitle("Новый видеорепортаж");

        Console.WriteLine($"Заголовок через производный тип: {videoArticle.Title}");
        Console.WriteLine($"Тот же объект: {ReferenceEquals(article, videoArticle)}");
        Console.WriteLine($"Фактический тип: {article.GetType().Name}");
        // Виртуальный вызов выбирает override по фактическому типу объекта: получим «Видео».
        Console.WriteLine($"Вызов через NewsArticle: {article.GetContentKind()}");
        Console.WriteLine($"Обычная новость: {DemoData.CreateArticle().GetContentKind()}");
        // VideoUrl объявлен только у производного класса. Через переменную article
        // типа NewsArticle это свойство напрямую недоступно.
        Console.WriteLine($"Видео: {videoArticle.VideoUrl}");
    }
}
