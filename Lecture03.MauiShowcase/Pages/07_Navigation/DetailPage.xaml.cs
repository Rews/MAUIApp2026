namespace Lecture03.MauiShowcase.Pages;

public partial class DetailPage : ContentPage
{
    public DetailPage()
    {
        InitializeComponent();
    }

    private async void OnBackClicked(object? sender, EventArgs e)
    {
        if (sender is not Button button) return;
        button.IsEnabled = false;
        // Маршрут «..» снимает текущую страницу со стека Shell и показывает предыдущую.
        try { await Shell.Current.GoToAsync(".."); }
        finally { button.IsEnabled = true; }
    }
}
