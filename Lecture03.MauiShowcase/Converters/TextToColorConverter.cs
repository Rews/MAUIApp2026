using System.Globalization;

namespace Lecture03.MauiShowcase.Converters;

public sealed class TextToColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        // Приводим ввод к единому виду: null → пустая строка, убираем пробелы и различия регистра.
        string name = (value as string ?? string.Empty).Trim().ToLowerInvariant();

        // Поддерживаем только перечисленные названия на русском и английском.
        return name switch
        {
            "красный" or "red" => Colors.Red,
            "зелёный" or "зеленый" or "green" => Colors.Green,
            "синий" or "blue" => Colors.Blue,
            "жёлтый" or "желтый" or "yellow" => Colors.Yellow,
            "оранжевый" or "orange" => Colors.Orange,
            "фиолетовый" or "purple" => Colors.Purple,
            // Для пустого или неизвестного названия возвращаем нейтральный цвет, а не ошибку.
            _ => Colors.LightGray
        };
    }

    // Привязка OneWay: цвет образца не записывается обратно в поле ввода.
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotSupportedException("Конвертер предназначен для привязки OneWay.");
}
