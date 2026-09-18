namespace CourseLecture02;

internal static class Program
{
    private static async Task<int> Main(string[] args)
    {
        string mode = args.Length == 0 ? "--demo" : args[0];
        if (args.Length > 1)
        {
            Console.WriteLine("Укажите один режим запуска.");
            return 1;
        }
        switch (mode)
        {
            case "--demo":
                await RunDemoAsync();
                return 0;
            case "--references":
                ShowReferences();
                return 0;
            case "--async":
                Console.WriteLine("Загрузка заголовка...");
                string title = await LoadTitleAsync();
                Console.WriteLine(title);
                return 0;
            case "--interactive":
                ReadPreviewLength();
                return 0;
            case "--errors":
                ShowErrors();
                return 0;
            case "--delegates":
                ShowDelegates();
                return 0;
            case "--events":
                ShowEvents();
                return 0;
            default:
                Console.WriteLine("Режимы: --demo, --references, --async, --interactive, --errors, --delegates, --events");
                return 1;
        }
    }

    private static async Task RunDemoAsync()
    {
        Console.WriteLine("Загрузка учебных новостей...");
        INewsSource source = new DemoNewsSource();
        List<NewsArticle> news = await source.LoadNewsAsync();
        Console.WriteLine($"Новостей: {news.Count}");
        foreach (NewsArticle item in news)
        {
            Console.WriteLine($"{item.Title}: {item.Text}");
            Console.WriteLine($"Изображение: {item.ImageUrl}");
        }
        var titles = news
            .Where(n => n.Title.Contains("УрФУ"))
            .OrderBy(n => n.Title)
            .Select(n => n.Title)
            .ToList();
        Console.WriteLine(string.Join(", ", titles));
        NewsArticle article = news[0];
        Console.WriteLine($"Анонс: {article.GetPreview(12)}");
    }

    private static NewsArticle CreateArticle()
    {
        return new NewsArticle("УрФУ: библиотека", "Открыт новый зал.",
            "https://example.org/1.jpg");
    }

    private static void ShowReferences()
    {
        var article = CreateArticle();
        NewsArticle? selected = article;
        selected.RenameTitle("Новый зал");
        Console.WriteLine($"article.Title: {article.Title}");
        Console.WriteLine($"selected.Title: {selected.Title}");
        selected = null;
        string title = selected?.Title ?? "Не выбрана";
        Console.WriteLine(title);
        Console.WriteLine($"article всё ещё доступна: {article.Title}");
    }

    private static async Task<string> LoadTitleAsync()
    {
        await Task.Delay(500);
        return "УрФУ: библиотека";
    }

    private static void ShowDelegates()
    {
        var article = CreateArticle();
        Action<NewsArticle> showTitle =
            n => Console.WriteLine(n.Title);
        Func<NewsArticle, string> getTitle =
            n => n.Title;

        showTitle(article);
        string title = getTitle(article);
        Console.WriteLine(title);

        Console.WriteLine("Передаём Action в ShowArticle:");
        ShowArticle(article, showTitle);
    }

    private static void ShowArticle(NewsArticle article, Action<NewsArticle> show)
    {
        show(article);
    }

    private static void ShowEvents()
    {
        var article = CreateArticle();
        Action<NewsArticle> handler =
            n => Console.WriteLine(n.Title);

        Console.WriteLine("Подписываем обработчик и меняем заголовок:");
        article.TitleChanged += handler;
        article.RenameTitle("Новый зал");

        Console.WriteLine("Повторяем тот же заголовок: уведомления не будет.");
        article.RenameTitle("  Новый зал  ");

        Console.WriteLine("Отписываем обработчик и меняем заголовок:");
        article.TitleChanged -= handler;
        article.RenameTitle("Другой зал");
        Console.WriteLine($"Текущий заголовок: {article.Title}");
    }

    private static void ReadPreviewLength()
    {
        var article = CreateArticle();
        Console.WriteLine($"Новость: {article.Title}");
        while (true)
        {
            Console.Write("Длина анонса или «выход»: ");
            string? input = Console.ReadLine();
            if (input is null || input.Trim().Equals("выход", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            if (!int.TryParse(input, out int length) || length <= 0)
            {
                Console.WriteLine("Нужно целое число больше нуля");
                continue;
            }
            Console.WriteLine(article.GetPreview(length));
        }
    }

    private static void ShowErrors()
    {
        var article = CreateArticle();
        try
        {
            Console.WriteLine(article.GetPreview(0));
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Проверьте длину");
        }
        Console.WriteLine($"Корректный анонс: {article.GetPreview(12)}");
        try
        {
            article.RenameTitle("   ");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Нужен непустой заголовок");
        }
        Console.WriteLine($"Заголовок сохранён: {article.Title}");
    }
}
