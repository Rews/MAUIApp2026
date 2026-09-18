namespace CourseLecture02;

public class VideoNewsArticle : NewsArticle
{
    public string VideoUrl { get; }

    public VideoNewsArticle(
        string title, string text, string imageUrl, string videoUrl)
        : base(title, text, imageUrl)
    {
        if (string.IsNullOrWhiteSpace(videoUrl))
        {
            throw new ArgumentException("Нужна ссылка на видео", nameof(videoUrl));
        }
        VideoUrl = videoUrl.Trim();
    }

    public override string GetContentKind()
    {
        return "Видео";
    }
}
