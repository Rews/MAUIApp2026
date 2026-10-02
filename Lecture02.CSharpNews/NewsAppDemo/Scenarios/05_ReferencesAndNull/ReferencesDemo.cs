namespace CourseLecture02;

// 05. Переменные ссылочного типа могут указывать на один объект.
// Присваивание ссылки не создаёт копию новости.

internal static class ReferencesDemo
{
    public static void Run()
    {
        var article = DemoData.CreateArticle();
        // ? разрешает значение null. Сейчас selected содержит ту же ссылку, что и article.
        NewsArticle? selected = article;
        // ReferenceEquals проверяет именно общий объект, а не совпадение его свойств.
        Console.WriteLine($"Тот же объект: {ReferenceEquals(article, selected)}");
        // Меняем общий объект через selected: новый заголовок будет виден и через article.
        // Компилятор знает, что после присваивания выше selected сейчас не равна null.
        selected.RenameTitle("Новый зал");
        Console.WriteLine($"article.Title: {article.Title}");
        Console.WriteLine($"selected.Title: {selected.Title}");
        // Убираем ссылку только из selected. Сам объект остаётся доступен через article.
        selected = null;
        // ?. не обращается к Title при null. Оператор ?? подставляет запасную строку,
        // когда выражение слева дало null.
        selected = null;
        string title = selected?.Title ?? "Не выбрана";
        Console.WriteLine(title);
        Console.WriteLine($"article всё ещё доступна: {article.Title}");
    }
}
