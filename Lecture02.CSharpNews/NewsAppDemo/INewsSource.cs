namespace CourseLecture02;

// Интерфейс — договор: источник должен предоставлять загрузку новостей.
// Здесь описан доступный метод, а конкретные действия находятся в DemoNewsSource.

public interface INewsSource
{
    // Task<List<NewsArticle>> представляет операцию, результат которой — список новостей.
    // Вызывающий код получает List<NewsArticle> после await. Суффикс Async — соглашение об имени.
    Task<List<NewsArticle>> LoadNewsAsync();
}
