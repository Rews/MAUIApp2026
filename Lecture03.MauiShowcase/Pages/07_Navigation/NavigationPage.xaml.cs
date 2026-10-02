namespace Lecture03.MauiShowcase.Pages;

public partial class NavigationPage : ContentPage
{
    public NavigationPage()
    {
        InitializeComponent();
    }

    private async void OnOpenDetailsClicked(object? sender, EventArgs e)
    {
        if (sender is not Button button) return;
        // На время перехода блокируем повторное нажатие; finally вернёт доступность кнопки.
        button.IsEnabled = false;
        // Имя маршрута совпадает с регистрацией в App.xaml.cs. Shell открывает DetailPage поверх текущей страницы.


        try
        {
            await Shell.Current.GoToAsync(nameof(DetailPage));
        }
        finally
        {
            button.IsEnabled = true;
        }
    }

    private async void OnAboutClicked(object? sender, EventArgs e) =>
        await DisplayAlertAsync("Лекция 03", "Контролы, контейнеры, локальные привязки и Shell.", "Понятно");

    // Технический переключатель двух демооболочек, не обычный переход между страницами.
    private void OnTabsClicked(object? sender, EventArgs e)
    {
        // Новая оболочка создаёт страницы заново: введённые значения предыдущей оболочки сбрасываются.
        if (Window is not null) Window.Page = new TabsShell();
    }

    private void OnFlyoutClicked(object? sender, EventArgs e)
    {
        if (Window is not null) Window.Page = new AppShell();
    }
}
