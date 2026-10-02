namespace Lecture03.MauiShowcase.Pages;

public partial class BindingsPage : ContentPage
{
    public BindingsPage()
    {
        InitializeComponent();
    }

    // Здесь только реакция на нажатие. Доступность кнопки и остальные изменения задают привязки в XAML.
    private void OnActionClicked(object? sender, EventArgs e) =>
        ActionResult.Text = "Кнопка нажата. Доступность задаёт локальная привязка.";
}
