using System.Globalization;

namespace Lecture03.MauiShowcase.Converters;

public sealed class BoolToStatusConverter : IValueConverter
{
    // IValueConverter преобразует значение источника в значение для целевого свойства. Здесь bool → string.
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        value is true ? "Уведомления включены" : "Уведомления выключены";

    // На странице используется Mode=OneWay: обратное преобразование не требуется.
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotSupportedException("Конвертер предназначен для привязки OneWay.");
}
