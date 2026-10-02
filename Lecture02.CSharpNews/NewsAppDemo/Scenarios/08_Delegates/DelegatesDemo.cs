namespace CourseLecture02;

// 08. Делегат хранит вызываемое действие, которое можно передать другому методу.
// Лямбда задаёт тело действия, а не выполняет его в момент объявления.

internal static class DelegatesDemo
{

    public static void Run()
    {
        var article = DemoData.CreateArticle();
        // Action<NewsArticle> принимает новость и ничего не возвращает (void).
        // В лямбде n — параметр, а справа от => находится выполняемое действие.
        Action<NewsArticle> showTitle =
            n => Console.WriteLine(n.Title);
        // У Func последний параметр типа — результат: здесь string.
        // Эта лямбда возвращает заголовок, сама ничего не печатает.
        Func<NewsArticle, string> getTitle =
            n => n.Title;

        // Скобки вызывают сохранённый делегат и передают ему article.
        showTitle(article);
        //showTitle?.Invoke(article);
        string title = getTitle(article);
        // Результат Func выводит вызывающий код — это отдельное действие.
        Console.WriteLine(title);

        Console.WriteLine("Передаём Action в ShowArticle:");
        ShowArticle(article, showTitle);

        Action<string> renameTitleAction = article.RenameTitle;
        renameTitleAction("Title");
    }


    // Метод получает и данные, и способ их показа. Можно передать другое действие
    // с той же сигнатурой, не меняя тело ShowArticle.
    private static void ShowArticle(NewsArticle article, Action<NewsArticle> show)
    {
        show(article);
    }
}
