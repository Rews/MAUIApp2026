namespace CourseLecture02;

// 12. LINQ: отбор объектов, сортировка и получение только заголовков.
// Поставьте точки останова после каждого ToList и сравните списки в отладчике.

internal static class CollectionsDemo
{
    public static void Run()
    {
        // List<NewsArticle> — список, элементы которого имеют тип NewsArticle.
        // Исходный порядок специально отличается от порядка сортировки.
        var news = new List<NewsArticle>
        {
            new NewsArticle("УрФУ: лаборатория", "Открыта лаборатория.", ""),
            new NewsArticle("Новости города", "Начался фестиваль.", ""),
            DemoData.CreateArticle()
        };
        Console.WriteLine("Исходный список:");
        foreach (NewsArticle article in news)
        {
            Console.WriteLine(article.Title);
        }

        // Для показа в отладчике сохраняем результат каждого шага отдельно.
        // Where оставляет элементы, для которых условие лямбды истинно.
        // Ordinal задаёт сравнение без языковых правил, с учётом регистра.
        // ToList выполняет перебор запроса и сохраняет результат в новый список.
        List<NewsArticle> filtered = news
            .Where(n => n.Title.Contains("УрФУ", StringComparison.Ordinal))
            .ToList();
        Console.WriteLine($"После Where: {filtered.Count}");
        foreach (NewsArticle article in filtered)
        {
            Console.WriteLine(article.Title);
        }

        // OrderBy упорядочивает результат по заголовку, не переставляя элементы filtered.
        // Здесь StringComparer.Ordinal делает сравнение независимым от текущей культуры.
        List<NewsArticle> sorted = filtered
            .OrderBy(n => n.Title, StringComparer.Ordinal)
            .ToList();
        Console.WriteLine("После OrderBy:");
        foreach (NewsArticle article in sorted)
        {
            Console.WriteLine(article.Title);
        }

        //var test = news.Where().Select().OrderBy().ToList();

        // Select преобразует каждый элемент: из NewsArticle получаем string.
        // Поэтому тип результата теперь List<string>, а не List<NewsArticle>.
        List<string> titles = sorted.Select(n => n.Title).ToList();
        Console.WriteLine($"После Select: {string.Join(", ", titles)}");
        // Исходный список не изменён. Однако filtered и sorted хранят ссылки
        // на те же объекты новостей: ToList не делает глубокие копии NewsArticle.
        Console.WriteLine($"Исходных новостей: {news.Count}");
        Console.WriteLine($"Первая исходная новость: {news[0].Title}");
    }
}
