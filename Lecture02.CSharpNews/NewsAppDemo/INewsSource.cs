namespace CourseLecture02;

public interface INewsSource
{
    Task<List<NewsArticle>> LoadNewsAsync();
}
