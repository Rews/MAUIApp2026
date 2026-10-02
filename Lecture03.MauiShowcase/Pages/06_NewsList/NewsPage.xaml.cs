namespace Lecture03.MauiShowcase.Pages;

public partial class NewsPage : ContentPage
{
    public NewsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // OnAppearing вызывается при показе страницы. ??= задаёт данные только если ItemsSource ещё null.
        NewsCollection.ItemsSource ??= new Models.NewsCard[]
        {
            new("Начинаем знакомство с MAUI", "Курс", "Собираем первый экран из готовых контролов."),
            new("Открылась лаборатория", "Кампус", "Студенты могут работать над мобильными приложениями."),
            new("Практика по XAML", "Занятия", "Сравниваем Grid, StackLayout и FlexLayout."),
            new("Встреча разработчиков", "События", "Обсуждаем интерфейсы для Android и iOS."),
            new("Новая подборка примеров", "Материалы", "Привязываем свойства контролов друг к другу."),
            new("Следующий экран", "Навигация", "Переходим к странице через маршрут Shell.")
        };
    }

    private void OnNewsSelected(object? sender, SelectionChangedEventArgs e)
    {

        // SelectionLabel.Text = $"SelectionMode: {NewsCollection.SelectionMode} " +
        //                       $"CurrentSelection: {e?.CurrentSelection?.Count} " +
        //                       $"SelectedItems: {NewsCollection.SelectedItems.Count}";
        
        // Выбор может быть пустым. Проверка is извлекает NewsCard только при наличии подходящего элемента.
        if (e.CurrentSelection.FirstOrDefault() is Models.NewsCard news)
            SelectionLabel.Text = $"Выбрано: {news.Title}";
    }
}
