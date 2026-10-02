namespace Lecture03.MauiShowcase.Pages;

public partial class ValuesPage : ContentPage
{
    public ValuesPage()
    {
        InitializeComponent();
    }

    // Храним отмену текущей загрузки, чтобы остановить её при уходе со страницы.
    private CancellationTokenSource? loadingCancellation;

    private void OnSizeChanged(object? sender, ValueChangedEventArgs e)
    {
        // XAML может вызвать событие до создания следующего элемента.
        if (SizePreview is not null)
            SizePreview.FontSize = e.NewValue;
    }

    private void OnTicketsChanged(object? sender, ValueChangedEventArgs e)
    {
        if (TicketLabel is not null)
            TicketLabel.Text = $"Билетов: {e.NewValue:0}";
    }

    // async void используется для обработчика события; await позволяет ожидать, не блокируя интерфейс.
    private async void OnLoadClicked(object? sender, EventArgs e)
    {
        // Не запускаем вторую загрузку, пока первая ещё выполняется.
        if (loadingCancellation is not null)
            return;

        using var cancellation = new CancellationTokenSource();
        loadingCancellation = cancellation;
        
        LoadButton.IsEnabled = false;
        LoadingIndicator.IsVisible = LoadingIndicator.IsRunning = true;
        LoadingProgress.Progress = 0;
        try
        {
            for (int step = 1; step <= 10; step++)
            {
                // Имитируем работу без сети. 10.0 ниже даёт дробную долю: 0.1, 0.2, …, 1.0.
                await Task.Delay(250, cancellation.Token);
                LoadingProgress.Progress = step / 10.0;
                LoadingStatus.Text = $"Загружено: {step * 10}%";
            }
            LoadingStatus.Text = "Загрузка завершена";
        }
        catch (OperationCanceledException)
        {
            LoadingStatus.Text = "Загрузка остановлена при уходе со страницы";
        }
        // Возвращаем кнопку и индикатор в исходное состояние и после успеха, и после отмены.
        finally
        {
            LoadingIndicator.IsVisible = LoadingIndicator.IsRunning = false;
            LoadButton.IsEnabled = true;
            loadingCancellation = null;
        }
    }

    protected override void OnDisappearing()
    {
        // Сигнал отмены прерывает ожидание Task.Delay; выше его обрабатывает catch.
        loadingCancellation?.Cancel();
        base.OnDisappearing();
    }
}
