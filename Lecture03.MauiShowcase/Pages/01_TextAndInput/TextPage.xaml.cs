namespace Lecture03.MauiShowcase.Pages;

// partial: этот код и код, сгенерированный из XAML, образуют один класс страницы.
public partial class TextPage : ContentPage
{
    public TextPage()
    {
        // Создаём элементы из XAML; после этого доступны поля с именами из x:Name.
        InitializeComponent();
    }

    private void OnPreviewClicked(object? sender, EventArgs e)
    {
        // Читаем введённый текст и меняем подписи напрямую. Пустой ввод заменяем подсказкой.
        PreviewTitle.Text = string.IsNullOrWhiteSpace(TitleEntry.Text)
            ? "Новость без заголовка" : TitleEntry.Text.Trim();
        PreviewSummary.Text = string.IsNullOrWhiteSpace(SummaryEditor.Text)
            ? "Описание пока не добавлено." : SummaryEditor.Text.Trim();
    }
}
