namespace CourseLecture02;

// Учебная реализация INewsSource: возвращает фиксированные данные, не обращается к сети.

public class DemoNewsSource : INewsSource
{
    public async Task<List<NewsArticle>> LoadNewsAsync()
    {
        // Имитируем задержку источника. Пока таймер не завершён, await приостанавливает
        // этот метод без блокировки ожидающего потока; отдельный поток явно не создаём.
        await Task.Delay(500);
        string imageUrl = "https://example.org/1.jpg";
        // После ожидания создаём новый список. В async-методе возвращаем сам результат;
        // вызывающий код получает его через Task<List<NewsArticle>>.
        return new List<NewsArticle>
        {
            new NewsArticle("УрФУ: библиотека", "Открыт новый зал.", imageUrl),
            new NewsArticle("Новости города", "Начался фестиваль.", imageUrl),
            new NewsArticle("УрФУ: лаборатория", "Открыта лаборатория.", imageUrl)
        };
    }
}
