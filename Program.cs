using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Конвертер чисел в текст");
        Console.WriteLine("-----------------------");
        Console.WriteLine("Введите число, род и падеж через пробел");
        Console.WriteLine("Или введите 'exit' для выхода");
        Console.WriteLine();
        Console.WriteLine("Пример: 154323 М И");
        Console.WriteLine();

        while (true)
        {
            try
            {
                Console.Write("> ");
                string input = Console.ReadLine()?.Trim();

                // Выход из программы
                if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Программа завершена.");
                    break;
                }

                // Пропуск пустых вводов
                if (string.IsNullOrWhiteSpace(input))
                    continue;

                // Обработка ввода
                ProcessInput(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine("Попробуйте снова. Пример ввода: 12345 Ж Р");
            }
        }
    }

    private static void ProcessInput(string input)
    {
        // Разбиваем ввод на части
        string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length != 3)
            throw new ArgumentException("Неверный формат ввода. Требуется три значения: число, род, падеж");

        // Парсим число
        if (!long.TryParse(parts[0], out long number))
            throw new ArgumentException("Неверный формат числа. Введите целое число");

        // Проверяем род
        string gender = parts[1].ToUpper();

        if (gender != "М" && gender != "Ж" && gender != "С")
            throw new ArgumentException("Неверный род. Используйте: М (мужской), Ж (женский), С (средний)");

        // Проверяем падеж
        string caseType = parts[2].ToUpper();

        if (caseType != "И" && caseType != "Р" && caseType != "Д" && caseType != "В" && caseType != "Т" && caseType != "П")
            throw new ArgumentException("Неверный падеж. Используйте: И, Р, Д, В, Т, П");

        // Преобразуем число в текст
        string result = NumberToWordsConverter.sumProp((int)number, gender, caseType);

        // Выводим результат
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Результат: {result}");
        Console.ResetColor();
    }
}