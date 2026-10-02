namespace CourseLecture02;

// Видеоновость расширяет NewsArticle: наследует общие данные и добавляет адрес видео.

public class VideoNewsArticle : NewsArticle
{
    public string VideoUrl { get; }

    public VideoNewsArticle(
        string title, string text, string imageUrl, string videoUrl)
        // base передаёт общую часть данных конструктору NewsArticle.
        // Он выполняется до тела конструктора VideoNewsArticle.
        : base(title, text, imageUrl)
    {
        // Правило производного класса: у видеоновости должна быть непустая ссылка.
        if (string.IsNullOrWhiteSpace(videoUrl))
        {
            throw new ArgumentException("Нужна ссылка на видео", nameof(videoUrl));
        }
        VideoUrl = videoUrl.Trim();
    }

    // Переопределяем виртуальный метод: для объекта VideoNewsArticle вернётся «Видео»,
    // даже если переменная при вызове имеет тип NewsArticle.
    public override string GetContentKind()
    {
        return "Видео";
    }
}
