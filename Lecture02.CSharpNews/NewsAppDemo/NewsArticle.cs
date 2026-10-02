namespace CourseLecture02;

// Модель новости: хранит данные и защищает правила их изменения.
// Свойства и методы разбираем в сценарии 04, событие — в 09, ошибки — в 15.

public class NewsArticle
{
    // Заголовок можно читать снаружи, но private set запрещает прямое присваивание.
    // Изменения проходят через RenameTitle, где проверяется новое значение.
    public string Title { get; private set; } = string.Empty;
    // Свойства только с get заполняются конструктором и затем доступны для чтения.
    public string Text { get; }
    public string ImageUrl { get; }

    // Событие передаёт подписчикам изменённую новость и не возвращает результат.
    // ? допускает отсутствие подписчиков. Снаружи можно подписаться/отписаться,
    // но вызвать это событие может код самого NewsArticle.
    public event Action<NewsArticle>? TitleChanged;

    // Конструктор вызывается при new. Если проверка выбросит исключение,
    // вызывающий код не получит успешно созданную новость.
    public NewsArticle(string title, string text, string imageUrl)
    {
        // Используем те же правила заголовка, что и при последующих переименованиях.
        RenameTitle(title);
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Нужен текст новости", nameof(text));
        }
        // Для адреса допускается пустая строка — картинки может не быть.
        // null запрещаем, чтобы свойство всегда содержало строку.
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
        // Убираем пробелы по краям до сравнения: «Новый зал» и «  Новый зал  » равнозначны.
        string newTitle = title.Trim();
        // Если значение не изменилось, уведомлять подписчиков не нужно.
        if (Title == newTitle)
        {
            return;
        }
        // Сначала сохраняем значение, затем уведомляем: обработчики увидят новый Title.
        Title = newTitle;
        // ?. вызывает обработчики только при наличии подписчиков.
        // this — текущий объект новости. Обработчики вызываются синхронно.
        TitleChanged?.Invoke(this);
    }

    public string GetPreview(int maxLength)
    {
        // Модель проверяет длину сама, даже если интерфейс уже проверял ввод.
        // nameof даёт имя параметра для диагностического сообщения исключения.
        if (maxLength <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxLength));
        }
        // Берём меньшую длину, чтобы Substring не вышел за границы текста.
        // Создаём строку анонса; исходное свойство Text не изменяется.
        int length = Math.Min(Text.Length, maxLength);
        return Text.Substring(0, length);
    }

    // virtual разрешает производному классу переопределить поведение через override.
    // Как выбирается реализация при вызове через базовый тип, показывает сценарий 06.
    public virtual string GetContentKind()
    {
        return "Текст";
    }
}
