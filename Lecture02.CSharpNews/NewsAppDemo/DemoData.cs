namespace CourseLecture02;

// Вспомогательная фабрика объектов для сценариев.
// Начать чтение лучше с Scenarios/01_Basics, а сюда переходить при вызове CreateArticle.

// Общие учебные данные. Каждый вызов создаёт новый объект.
internal static class DemoData
{
    // Стрелка => — краткая запись метода, который возвращает одно выражение.
    // Новый объект при каждом вызове позволяет повторять сценарии с исходными данными.
    public static NewsArticle CreateArticle() =>
        new NewsArticle("УрФУ: библиотека", "Открыт новый зал.", "https://example.org/1.jpg");

    // Видеоновость нужна для сравнения базового и производного типов.
    // Адреса в этих данных — строки для примера; файлы по ним не загружаются.
    public static VideoNewsArticle CreateVideoArticle() =>
        new VideoNewsArticle("УрФУ: видеорепортаж", "Репортаж из нового зала.",
            "https://example.org/1.jpg", "https://example.org/report.mp4");
}
