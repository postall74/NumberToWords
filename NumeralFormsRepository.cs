using System.Collections.Generic;

public static class NumeralFormsRepository
{
    private static readonly string[][][] Units = InitializeUnits();
    private static readonly string[][] Teens = InitializeTeens();
    private static readonly string[][] Tens = InitializeTens();
    private static readonly string[][] Hundreds = InitializeHundreds();
    private static readonly Dictionary<NumberClass, string[][]> ClassForms = InitializeClassForms();

    public static string GetUnitForm(int number, Gender gender, GrammaticalCase grammaticalCase)
    {
        if (number < 1 || number > 9) // Исправлено
            return "";

        return Units[number][(int)gender][(int)grammaticalCase];
    }

    public static string GetTeenForm(int number, GrammaticalCase grammaticalCase)
    {
        if (number < 10 || number > 19) // Исправлено
            return "";

        return Teens[number - 10][(int)grammaticalCase];
    }

    public static string GetTenForm(int number, GrammaticalCase grammaticalCase)
    {
        if (number < 2 || number > 9) 
            return "";

        return Tens[number][(int)grammaticalCase]; // Убрано -2
    }

    public static string GetHundredForm(int number, GrammaticalCase grammaticalCase)
    {
        if (number < 1 || number > 9) 
            return "";

        return Hundreds[number][(int)grammaticalCase];
    }

    public static string GetClassForm(NumberClass numberClass, int number, GrammaticalCase grammaticalCase)
    {
        int index = GetClassFormIndex(number);
        return ClassForms[numberClass][(int)grammaticalCase][index];
    }

    private static int GetClassFormIndex(int number)
    {
        int lastTwo = number % 100;

        if (lastTwo >= 11 && lastTwo <= 19)
            return 2;

        int lastDigit = number % 10;

        // Исправляем для C# 7.3
        if (lastDigit == 1)
            return 0;

        if (lastDigit >= 2 && lastDigit <= 4)
            return 1;

        return 2;
    }

    // Инициализация всех форм чисел (аналогично предыдущей реализации)
    private static string[][][] InitializeUnits()
    {
        var units = new string[10][][]; // 0-9

        // Инициализируем все элементы
        for (int i = 0; i < 10; i++)
        {
            units[i] = new string[3][];
        }

        // 1
        units[1][0] = new string[] { "один", "одного", "одному", "один", "одним", "одном" };
        units[1][1] = new string[] { "одна", "одной", "одной", "одну", "одной", "одной" };
        units[1][2] = new string[] { "одно", "одного", "одному", "одно", "одным", "одном" };

        // 2
        units[2][0] = new string[] { "два", "двух", "двум", "два", "двумя", "двух" };
        units[2][1] = new string[] { "две", "двух", "двум", "две", "двумя", "двух" };
        units[2][2] = new string[] { "два", "двух", "двум", "два", "двумя", "двух" };

        // 3-9
        string[] three = { "три", "трех", "трем", "три", "тремя", "трех" };
        string[] four = { "четыре", "четырех", "четырем", "четыре", "четырьмя", "четырех" };
        string[] five = { "пять", "пяти", "пяти", "пять", "пятью", "пяти" };
        string[] six = { "шесть", "шести", "шести", "шесть", "шестью", "шести" };
        string[] seven = { "семь", "семи", "семи", "семь", "семью", "семи" };
        string[] eight = { "восемь", "восьми", "восьми", "восемь", "восемью", "восьми" };
        string[] nine = { "девять", "девяти", "девяти", "девять", "девятью", "девяти" };

        for (int i = 3; i <= 9; i++)
        {
            string[] forms = i == 3 ? three :
                            i == 4 ? four :
                            i == 5 ? five :
                            i == 6 ? six :
                            i == 7 ? seven :
                            i == 8 ? eight : nine;

            for (int j = 0; j < 3; j++)
            {
                units[i][j] = forms;
            }
        }

        return units;
    }

    private static string[][] InitializeTeens()
    {
        var teens = new string[10][];
        teens[0] = new string[] { "десять", "десяти", "десяти", "десять", "десятью", "десяти" };
        teens[1] = new string[] { "одиннадцать", "одиннадцати", "одиннадцати", "одиннадцать", "одиннадцатью", "одиннадцати" };
        teens[2] = new string[] { "двенадцать", "двенадцати", "двенадцати", "двенадцать", "двенадцатью", "двенадцати" };
        teens[3] = new string[] { "тринадцать", "тринадцати", "тринадцати", "тринадцать", "тринадцатью", "тринадцати" };
        teens[4] = new string[] { "четырнадцать", "четырнадцати", "четырнадцати", "четырнадцать", "четырнадцатью", "четырнадцати" };
        teens[5] = new string[] { "пятнадцать", "пятнадцати", "пятнадцати", "пятнадцать", "пятнадцатью", "пятнадцати" };
        teens[6] = new string[] { "шестнадцать", "шестнадцати", "шестнадцати", "шестнадцать", "шестнадцатью", "шестнадцати" };
        teens[7] = new string[] { "семнадцать", "семнадцати", "семнадцати", "семнадцать", "семнадцатью", "семнадцати" };
        teens[8] = new string[] { "восемнадцать", "восемнадцати", "восемнадцати", "восемнадцать", "восемнадцатью", "восемнадцати" };
        teens[9] = new string[] { "девятнадцать", "девятнадцати", "девятнадцати", "девятнадцать", "девятнадцатью", "девятнадцати" };

        return teens;
    }

    private static string[][] InitializeTens()
    {
        var tens = new string[10][]; // 0-9

        // Заполняем только нужные индексы (2-9)
        tens[2] = new string[] { "двадцать", "двадцати", "двадцати", "двадцать", "двадцатью", "двадцати" };
        tens[3] = new string[] { "тридцать", "тридцати", "тридцати", "тридцать", "тридцатью", "тридцати" };
        tens[4] = new string[] { "сорок", "сорока", "сорока", "сорок", "сорока", "сорока" };
        tens[5] = new string[] { "пятьдесят", "пятидесяти", "пятидесяти", "пятьдесят", "пятьюдесятью", "пятидесяти" };
        tens[6] = new string[] { "шестьдесят", "шестидесяти", "шестидесяти", "шестьдесят", "шестьюдесятью", "шестидесяти" };
        tens[7] = new string[] { "семьдесят", "семидесяти", "семидесяти", "семьдесят", "семьюдесятью", "семидесяти" };
        tens[8] = new string[] { "восемьдесят", "восьмидесяти", "восьмидесяти", "восемьдесят", "восемьюдесятью", "восьмидесяти" };
        tens[9] = new string[] { "девяносто", "девяноста", "девяноста", "девяносто", "девяноста", "девяноста" };

        return tens;
    }

    private static string[][] InitializeHundreds()
    {
        var hundreds = new string[10][]; // 0-9

        // Заполняем только нужные индексы (1-9)
        hundreds[1] = new string[] { "сто", "ста", "ста", "сто", "ста", "ста" };
        hundreds[2] = new string[] { "двести", "двухсот", "двумстам", "двести", "двумястами", "двухстах" };
        hundreds[3] = new string[] { "триста", "трехсот", "тремстам", "триста", "тремястами", "трехстах" };
        hundreds[4] = new string[] { "четыреста", "четырехсот", "четыремстам", "четыреста", "четырьмястами", "четырехстах" };
        hundreds[5] = new string[] { "пятьсот", "пятисот", "пятистам", "пятьсот", "пятьюстами", "пятистах" };
        hundreds[6] = new string[] { "шестьсот", "шестисот", "шестистам", "шестьсот", "шестьюстами", "шестистах" };
        hundreds[7] = new string[] { "семьсот", "семисот", "семистам", "семьсот", "семьюстами", "семистах" };
        hundreds[8] = new string[] { "восемьсот", "восьмисот", "восьмистам", "восемьсот", "восемьюстами", "восьмистах" };
        hundreds[9] = new string[] { "девятьсот", "девятисот", "девятистам", "девятьсот", "девятьюстами", "девятистах" };

        return hundreds;
    }

    private static Dictionary<NumberClass, string[][]> InitializeClassForms()
    {
        return new Dictionary<NumberClass, string[][]>
        {
            {
                NumberClass.Thousands,
                new string[][]
                {
                    new string[] { "тысяча", "тысячи", "тысяч" },
                    new string[] { "тысячи", "тысяч", "тысяч" },
                    new string[] { "тысяче", "тысячам", "тысячам" },
                    new string[] { "тысячу", "тысячи", "тысяч" },
                    new string[] { "тысячей", "тысячами", "тысячами" },
                    new string[] { "тысяче", "тысячах", "тысячах" }
                }
            },
            {
                NumberClass.Millions,
                new string[][]
                {
                    new string[] { "миллион", "миллиона", "миллионов" },
                    new string[] { "миллиона", "миллионов", "миллионов" },
                    new string[] { "миллиону", "миллионам", "миллионам" },
                    new string[] { "миллион", "миллиона", "миллионов" },
                    new string[] { "миллионом", "миллионами", "миллионами" },
                    new string[] { "миллионе", "миллионах", "миллионах" }
                }
            },
            {
                NumberClass.Billions,
                new string[][]
                {
                    new string[] { "миллиард", "миллиарда", "миллиардов" },
                    new string[] { "миллиарда", "миллиардов", "миллиардов" },
                    new string[] { "миллиарду", "миллиардам", "миллиардам" },
                    new string[] { "миллиард", "миллиарда", "миллиардов" },
                    new string[] { "миллиардом", "миллиардами", "миллиардами" },
                    new string[] { "миллиарде", "миллиардах", "миллиардах" }
                }
            }
        };
    }
}