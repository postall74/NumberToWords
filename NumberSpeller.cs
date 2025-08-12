using System.Collections.Generic;

public class NumberSpeller
{
    public string SpellPart(NumberPart part, Gender gender, GrammaticalCase grammaticalCase)
    {
        int number = part.Value;

        if (number == 0) 
            return "";

        List<string> parts = new List<string>();
        int hundreds = number / 100;
        int remainder = number % 100;

        // Сотни
        if (hundreds > 0)
            parts.Add(NumeralFormsRepository.GetHundredForm(hundreds, grammaticalCase));

        // Десятки и единицы
        if (remainder > 0)
        {
            if (remainder < 10)
            {
                parts.Add(NumeralFormsRepository.GetUnitForm(
                    remainder,
                    part.Class == NumberClass.Units ? gender : Gender.Feminine,
                    grammaticalCase
                ));
            }
            else if (remainder < 20)
            {
                parts.Add(NumeralFormsRepository.GetTeenForm(remainder, grammaticalCase));
            }
            else
            {
                int tens = remainder / 10;
                int units = remainder % 10;

                parts.Add(NumeralFormsRepository.GetTenForm(tens, grammaticalCase));
                if (units > 0)
                {
                    parts.Add(NumeralFormsRepository.GetUnitForm(
                        units,
                        part.Class == NumberClass.Units ? gender : Gender.Feminine,
                        grammaticalCase
                    ));
                }
            }
        }

        // Добавляем название класса
        if (part.Class != NumberClass.Units)
        {
            parts.Add(NumeralFormsRepository.GetClassForm(
                part.Class,
                number,
                grammaticalCase
            ));
        }

        return string.Join(" ", parts);
    }
}