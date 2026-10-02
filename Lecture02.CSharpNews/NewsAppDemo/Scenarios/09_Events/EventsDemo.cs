namespace CourseLecture02;

// 09. Событие уведомляет несколько подписчиков об изменении модели.
// Посчитайте вызовы: «экран» получит одно уведомление, «журнал» — два.

internal static class EventsDemo
{
    public static void Run()
    {
        var article = DemoData.CreateArticle();
        // «Экран» и «журнал» здесь обозначают два обычных консольных обработчика.
        Action<NewsArticle> screen = n => Console.WriteLine($"Экран: {n.Title}");
        Action<NewsArticle> log = n => Console.WriteLine($"Журнал: {n.Title}");

        Console.WriteLine("1. Подписываем два обработчика и меняем заголовок:");
        // += добавляет обработчик. Подписка сама по себе его не вызывает.
        article.TitleChanged += screen;
        article.TitleChanged += log;
        //article.SubscribeOnTitleChanged(screen);
        // RenameTitle изменит Title и вызовет событие; сработают оба подписчика.
        // Источник события находится в NewsArticle, а реакции на него — в этом сценарии.
        article.RenameTitle("Новый зал");

        Console.WriteLine("2. Повторяем тот же заголовок: уведомлений нет.");
        // После Trim значение совпадёт с текущим: модель не вызовет событие повторно.
        article.RenameTitle("  Новый зал  ");

        Console.WriteLine("3. Отписываем экран, журнал остаётся:");
        // -= удаляет конкретный делегат. Для отписки используем сохранённую переменную,
        // а не создаём новую, похожую лямбду. Подписка журнала остаётся.
        article.TitleChanged -= screen;
        article.RenameTitle("Другой зал");

        Console.WriteLine("4. Отписываем журнал: обработчиков больше нет.");
        article.TitleChanged -= log;
        // Без подписчиков значение по-прежнему меняется; ?.Invoke в модели безопасно пропускает вызов.
        article.RenameTitle("Зал открыт");
        Console.WriteLine($"Текущий заголовок: {article.Title}");
    }
}
