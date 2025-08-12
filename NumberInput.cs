using System;
using System.Linq;

public class NumberInput
{
    public long Value { get; }
    public string Gender { get; }
    public string Case { get; }

    public NumberInput(long value, string gender, string caseType)
    {
        if (Math.Abs(value) >= 1_000_000_000_000)
            throw new ArgumentException("Число слишком большое. Максимум: 999 999 999 999");

        if (!new[] { "М", "Ж", "С" }.Contains(gender))
            throw new ArgumentException("Недопустимый род. Используйте: М, Ж, С");

        if (!new[] { "И", "Р", "Д", "В", "Т", "П" }.Contains(caseType))
            throw new ArgumentException("Недопустимый падеж. Используйте: И, Р, Д, В, Т, П");

        Value = value;
        Gender = gender;
        Case = caseType;
    }
}