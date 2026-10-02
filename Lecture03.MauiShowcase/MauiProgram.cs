using Microsoft.Extensions.Logging;

namespace Lecture03.MauiShowcase;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		// Точка настройки MAUI: указываем класс приложения App и регистрируем имена шрифтов.
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		// Создаём приложение из подготовленных настроек.
		return builder.Build();
	}
}
