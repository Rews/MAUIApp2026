namespace CourseLecture02;

public class DemoNewsSource : INewsSource
{
    public async Task<List<NewsArticle>> LoadNewsAsync()
    {
        await Task.Delay(500);
        string imageUrl = "https://example.org/1.jpg";
        return new List<NewsArticle>
        {
            new NewsArticle("УрФУ: библиотека", "Открыт новый зал.", imageUrl),
            new NewsArticle("Новости города", "Начался фестиваль.", imageUrl),
            new NewsArticle("УрФУ: лаборатория", "Открыта лаборатория.", imageUrl)
        };
    }
}
