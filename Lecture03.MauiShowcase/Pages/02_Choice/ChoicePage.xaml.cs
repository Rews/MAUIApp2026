namespace Lecture03.MauiShowcase.Pages;

public partial class ChoicePage : ContentPage
{
    public ChoicePage()
    {
        InitializeComponent();
    }

    private void OnShowChoiceClicked(object? sender, EventArgs e)
    {
        // У CheckBox/RadioButton состояние хранится в IsChecked, у Switch — в IsToggled.
        string attendance = OfflineRadio.IsChecked ? "в аудитории" : "онлайн";
        // Дата и время могут отсутствовать: ?. безопасно форматирует значение, ?? даёт запасную подпись.
        string date = LessonDate.Date?.ToString("dd.MM.yyyy") ?? "не выбрана";
        string time = LessonTime.Time?.ToString(@"hh\:mm") ?? "не выбрано";
        // Собираем результат при нажатии кнопки; изменение контролов само эту подпись не обновляет.
        ChoiceResult.Text = $"Участие: {(ConsentCheck.IsChecked ? "подтверждено" : "не подтверждено")}\n"
            + $"Напоминание: {(ReminderSwitch.IsToggled ? "включено" : "выключено")}\n"
            + $"Формат: {attendance}\nТема: {TopicPicker.SelectedItem ?? "не выбрана"}\n"
            + $"Дата: {date}, время: {time}";
    }
}
