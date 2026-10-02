namespace CourseLecture02;

// 14. Проверка ввода: здесь число означает длину анонса, а не номер сценария.
// Команда «выход» возвращает в Program, где снова можно выбрать сценарий.

internal static class InputDemo
{
    public static void Run()
    {
        var article = DemoData.CreateArticle();
        Console.WriteLine($"Новость: {article.Title}");
        // Цикл позволяет несколько раз проверить длину на одной новости.
        while (true)
        {
            Console.Write("Длина анонса или «выход» в меню: ");
            // ReadLine возвращает текст или null при конце входного потока.
            string? input = Console.ReadLine();
            // || не вычисляет правую часть, если слева уже true: при null вызова Trim не будет.
            // Trim убирает пробелы по краям, OrdinalIgnoreCase разрешает любой регистр команды.
            if (input is null || input.Trim().Equals("выход", StringComparison.OrdinalIgnoreCase))
            {
                // Завершаем только Run и возвращаем управление вызывающему коду в Program.
                return;
            }
            // Сначала разбираем текст в int, затем проверяем допустимую длину.
            // 0 здесь не означает выход: у анонса должна быть положительная длина.
            if (!int.TryParse(input, out int length) || length <= 0)
            {
                Console.WriteLine("Нужно целое число больше нуля");
                // Пропускаем GetPreview для неверных данных и снова запрашиваем ввод.
                continue;
            }
            // После проверки передаём число модели. Она дополнительно проверяет свои правила
            // и ограничивает длину анонса фактической длиной текста.
            Console.WriteLine(article.GetPreview(length));
        }
    }
}
