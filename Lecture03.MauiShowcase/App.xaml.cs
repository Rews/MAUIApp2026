namespace Lecture03.MauiShowcase;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        // Фиксируем светлую тему для показа на проекторе.
        UserAppTheme = AppTheme.Light;
        // Связываем имя маршрута с типом страницы. По этому имени вызывается GoToAsync в NavigationPage.
        Routing.RegisterRoute(nameof(Pages.DetailPage), typeof(Pages.DetailPage));
    }

    // Создаём окно с AppShell: оболочка задаёт меню и начальную страницу приложения.
    protected override Window CreateWindow(IActivationState? activationState) =>
        new(new AppShell()) { Title = "MAUI · Лекция 03", Width = 1040, Height = 820 };
}
