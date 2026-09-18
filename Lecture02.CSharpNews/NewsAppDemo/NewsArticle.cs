namespace CourseLecture02;

public class NewsArticle
{
    public string Title { get; private set; } = string.Empty;
    public string Text { get; }
    public string ImageUrl { get; }

    public event Action<NewsArticle>? TitleChanged;

    public NewsArticle(string title, string text, string imageUrl)
    {
        RenameTitle(title);
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Нужен текст новости", nameof(text));
        }
        ArgumentNullException.ThrowIfNull(imageUrl);
        Text = text;
        ImageUrl = imageUrl.Trim();
    }

    public void RenameTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Нужен заголовок", nameof(title));
        }
        string newTitle = title.Trim();
        if (Title == newTitle)
        {
            return;
        }
        Title = newTitle;
        TitleChanged?.Invoke(this);
    }

    public string GetPreview(int maxLength)
    {
        if (maxLength <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxLength));
        }
        int length = Math.Min(Text.Length, maxLength);
        return Text.Substring(0, length);
    }

    public virtual string GetContentKind()
    {
        return "Текст";
    }
}
