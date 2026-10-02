namespace CourseLecture02;

// 13. Собираем изученное: интерфейс → асинхронная загрузка → LINQ → вызов метода модели.

internal static class NewsFeedDemo
{
    public static async Task RunAsync()
    {
        Console.WriteLine("Загрузка учебных новостей...");
        // Переменная объявлена через интерфейс, а объект — конкретная реализация.
        // Дальше код обращается к методу, описанному в INewsSource.
        INewsSource source = new DemoNewsSource();
        //source = new ExNewsSource();
        // До завершения загрузки списка ещё нет. await даёт готовый результат Task<List<NewsArticle>>.
        List<NewsArticle> news = await source.LoadNewsAsync();
        Console.WriteLine($"Новостей: {news.Count}");
        foreach (NewsArticle item in news)
        {
            Console.WriteLine($"{item.Title}: {item.Text}");
            Console.WriteLine($"Изображение: {item.ImageUrl}");
        }
        // Объединяем шаги сценария 12 в цепочку: отобрать → отсортировать → взять заголовки.
        // Лямбда n получает текущий элемент; каждый шаг передаёт последовательность следующему.
        // Перебор цепочки выполняется при ToList.
        var titles = news
            .Where(n => n.Title.Contains("УрФУ", StringComparison.Ordinal))
            .OrderBy(n => n.Title, StringComparer.Ordinal)
            .Select(n => n.Title)
            .ToList();
        Console.WriteLine(string.Join(", ", titles));
        // Индекс 0 — первая новость исходного списка. Учебный источник всегда даёт три новости;
        // для источника с возможным пустым списком перед индексированием нужна проверка.
        NewsArticle article = news[0];
        // Правила длины и получения анонса остаются в модели NewsArticle.
        Console.WriteLine($"Анонс: {article.GetPreview(12)}");
    }
}
