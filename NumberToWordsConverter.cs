using System.Collections.Generic;

public static class NumberToWordsConverter
{
    public static string Convert(NumberInput input)
    {
        // Обработка отрицательных чисел
        long value = input.Value;
        bool isNegative = false;

        if (value < 0)
        {
            isNegative = true;
            value = -value; // Преобразуем в положительное для обработки
        }

        // Обработка нуля
        if (value == 0)
            return GetZeroForm(input.Case);

        var rule = new GenderCaseRule(input.Gender, input.Case);
        var parts = NumberPartitioner.Partition(value); // Работаем с абсолютным значением
        var speller = new NumberSpeller();

        List<string> resultParts = new List<string>();

        // Добавляем "минус" для отрицательных чисел
        if (isNegative)
            resultParts.Add("минус");

        // Обрабатываем части числа
        foreach (var part in parts)
        {
            string spelled = speller.SpellPart(part, rule.Gender, rule.Case);

            if (!string.IsNullOrEmpty(spelled))
                resultParts.Add(spelled);
        }

        return string.Join(" ", resultParts);
    }

    private static string GetZeroForm(string caseType)
    {
        switch (caseType)
        {
            case "И": return "ноль";
            case "Р": return "ноля";
            case "Д": return "нолю";
            case "В": return "ноль";
            case "Т": return "нолём";
            case "П": return "ноле";
            default: return "ноль";
        }
    }

    // Фасадный метод для сохранения старого интерфейса
    public static string sumProp(int nSum, string sGender, string sCase)
    {
        return Convert(new NumberInput(nSum, sGender, sCase));
    }
}