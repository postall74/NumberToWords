using System;

public enum Gender
{
    Masculine,  // М
    Feminine,   // Ж
    Neuter      // С
}

public enum GrammaticalCase
{
    Nominative,     // И
    Genitive,       // Р
    Dative,         // Д
    Accusative,     // В
    Instrumental,   // Т
    Prepositional   // П
}

public class GenderCaseRule
{
    public Gender Gender { get; }
    public GrammaticalCase Case { get; }

    public GenderCaseRule(string gender, string caseType)
    {
        switch (gender)
        {
            case "М":
                Gender = Gender.Masculine;
                break;
            case "Ж":
                Gender = Gender.Feminine;
                break;
            case "С":
                Gender = Gender.Neuter;
                break;
            default:
                throw new ArgumentException("Недопустимый род");
        }

        switch (caseType)
        {
            case "И":
                Case = GrammaticalCase.Nominative;
                break;
            case "Р":
                Case = GrammaticalCase.Genitive;
                break;
            case "Д":
                Case = GrammaticalCase.Dative;
                break;
            case "В":
                Case = GrammaticalCase.Accusative;
                break;
            case "Т":
                Case = GrammaticalCase.Instrumental;
                break;
            case "П":
                Case = GrammaticalCase.Prepositional;
                break;
            default:
                throw new ArgumentException("Недопустимый падеж");
        }
    }
}