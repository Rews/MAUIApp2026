namespace CourseLecture02;

// 07. is, as и явное приведение: три способа работы с фактическим типом объекта.
// Сравните результаты для видеоновости, обычной новости и null.

internal static class TypeChecksDemo
{
    public static void Run()
    {
        var videoArticle = DemoData.CreateVideoArticle();
        NewsArticle article = videoArticle;
        // is одновременно проверяет совместимость типа и создаёт переменную video.
        // Внутри успешной ветки она доступна как VideoNewsArticle и не равна null.
        if (article is VideoNewsArticle video)
        {
            Console.WriteLine(video.VideoUrl);
        }

        // as возвращает ссылку нужного типа либо null при несовместимости.
        // Перед доступом к свойствам нужно учесть возможность null.
        VideoNewsArticle? maybeVideo =
            article as VideoNewsArticle;
        Console.WriteLine(
            maybeVideo?.VideoUrl ?? "Без видео");

        // Здесь явное приведение успешно: фактический объект — VideoNewsArticle.
        // Приведение меняет доступный тип ссылки, не превращает один объект в другой.
        var explicitVideo = (VideoNewsArticle)article;
        Console.WriteLine($"Явное приведение сохраняет объект: {ReferenceEquals(article, explicitVideo)}");

        // Обычная новость не является видеоновостью: is даст false, as — null.
        NewsArticle textArticle = DemoData.CreateArticle();
        Console.WriteLine($"Обычная новость, is: {textArticle is VideoNewsArticle}");
        Console.WriteLine($"Обычная новость, as даёт null: {(textArticle as VideoNewsArticle) is null}");
        // Для null проверка is тоже даёт false, а as оставляет null.
        NewsArticle? selected = null;
        Console.WriteLine($"null, is: {selected is VideoNewsArticle}");
        Console.WriteLine($"null, as даёт null: {(selected as VideoNewsArticle) is null}");

        try
        {
            // Явное приведение несовместимого объекта вызывает InvalidCastException.
            // Это учебная ошибка; для ожидаемо разных типов удобнее предварительная проверка is.
            var invalidVideo = (VideoNewsArticle)textArticle;
            Console.WriteLine(invalidVideo.VideoUrl);
        }
        catch (InvalidCastException)
        {
            Console.WriteLine("Явное приведение: несовместимый тип");
        }
    }
}
