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
            case "--conversions":
                ShowConversions();
                return 0;
            case "--inheritance":
                ShowInheritance();
                return 0;
            case "--type-checks":
                ShowTypeChecks();
                return 0;
            default:
                Console.WriteLine("Режимы: --demo, --references, --async, --interactive, --errors, --delegates, --events, --conversions, --inheritance, --type-checks");
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

    private static void ShowConversions()
    {
        int newsCount = 3;
        double countAsDouble = newsCount;
        double readingMinutes = 2.8;
        int wholeMinutes = (int)readingMinutes;

        bool parsed = int.TryParse("12", out int limit);
        Console.WriteLine(wholeMinutes);
        Console.WriteLine(limit);
        Console.WriteLine($"Количество как double: {countAsDouble}");
        Console.WriteLine($"TryParse для 12: {parsed}");

        bool invalidParsed = int.TryParse("двенадцать", out int invalidLimit);
        Console.WriteLine($"TryParse для текста: {invalidParsed}, результат: {invalidLimit}");
        try
        {
            double tooLarge = (double)int.MaxValue + 1;
            int impossible = checked((int)tooLarge);
            Console.WriteLine(impossible);
        }
        catch (OverflowException)
        {
            Console.WriteLine("checked: число вне диапазона int");
        }
    }

    private static VideoNewsArticle CreateVideoArticle()
    {
        return new VideoNewsArticle(
            "УрФУ: видеорепортаж", "Репортаж из нового зала.",
            "https://example.org/1.jpg", "https://example.org/report.mp4");
    }

    private static void ShowInheritance()
    {
        var videoArticle = CreateVideoArticle();
        NewsArticle article = videoArticle;
        Console.WriteLine(article.Title);
        article.RenameTitle("Новый видеорепортаж");

        Console.WriteLine($"Заголовок через производный тип: {videoArticle.Title}");
        Console.WriteLine($"Тот же объект: {ReferenceEquals(article, videoArticle)}");
        Console.WriteLine($"Фактический тип: {article.GetType().Name}");
        Console.WriteLine($"Вызов через NewsArticle: {article.GetContentKind()}");
        Console.WriteLine($"Обычная новость: {CreateArticle().GetContentKind()}");
        Console.WriteLine($"Видео: {videoArticle.VideoUrl}");
    }

    private static void ShowTypeChecks()
    {
        var videoArticle = CreateVideoArticle();
        NewsArticle article = videoArticle;
        if (article is VideoNewsArticle video)
        {
            Console.WriteLine(video.VideoUrl);
        }

        VideoNewsArticle? maybeVideo =
            article as VideoNewsArticle;
        Console.WriteLine(
            maybeVideo?.VideoUrl ?? "Без видео");

        var explicitVideo = (VideoNewsArticle)article;
        Console.WriteLine($"Явное приведение сохраняет объект: {ReferenceEquals(article, explicitVideo)}");

        NewsArticle textArticle = CreateArticle();
        Console.WriteLine($"Обычная новость, is: {textArticle is VideoNewsArticle}");
        Console.WriteLine($"Обычная новость, as даёт null: {(textArticle as VideoNewsArticle) is null}");
        NewsArticle? selected = null;
        Console.WriteLine($"null, is: {selected is VideoNewsArticle}");
        Console.WriteLine($"null, as даёт null: {(selected as VideoNewsArticle) is null}");

        try
        {
            var invalidVideo = (VideoNewsArticle)textArticle;
            Console.WriteLine(invalidVideo.VideoUrl);
        }
        catch (InvalidCastException)
        {
            Console.WriteLine("Явное приведение: несовместимый тип");
        }
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
