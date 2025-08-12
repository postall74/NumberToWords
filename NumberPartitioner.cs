using System;
using System.Collections.Generic;

public static class NumberPartitioner
{
    public static IEnumerable<NumberPart> Partition(long number)
    {
        if (number == 0)
        {
            yield return new NumberPart(0, NumberClass.Units);
            yield break;
        }

        number = Math.Abs(number);

        // Порядок обработки классов от старшего к младшему
        var classes = new[]
        {
            (divisor: 1_000_000_000L, classType: NumberClass.Billions),
            (divisor: 1_000_000L, classType: NumberClass.Millions),
            (divisor: 1_000L, classType: NumberClass.Thousands)
        };

        foreach (var cls in classes)
        {
            if (number < cls.divisor) continue;

            int part = (int)(number / cls.divisor);
            number %= cls.divisor;

            if (part > 0)
                yield return new NumberPart(part, cls.classType);
        }

        if (number > 0)
            yield return new NumberPart((int)number, NumberClass.Units);
    }
}

public class NumberPart
{
    public int Value { get; }
    public NumberClass Class { get; }

    public NumberPart(int value, NumberClass numberClass)
    {
        Value = value;
        Class = numberClass;
    }
}

public enum NumberClass
{
    None,
    Units,      // 1-999
    Thousands,  // 10^3
    Millions,   // 10^6
    Billions    // 10^9
}