namespace TP_1;

public class RomanConverter
{
    private static readonly Dictionary<char, int> romanValues = new Dictionary<char, int>
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 },
        { 'G', 5000 },
        { 'H', 10000 },
        { 'J', 50000 },
        { 'K', 100000 },
        { 'F', 500000 },
        { 'P', 1000000 }
    };

    private static readonly Dictionary<char, string> symbolDescriptions =
        new Dictionary<char, string>
        {
            { 'I', "1" },
            { 'V', "5" },
            { 'X', "10" },
            { 'L', "50" },
            { 'C', "100" },
            { 'D', "500" },
            { 'M', "1 000" },
            { 'G', "5 000" },
            { 'H', "10 000" },
            { 'J', "50 000" },
            { 'K', "100 000" },
            { 'F', "500 000" },
            { 'P', "1 000 000" }
        };

    public static Dictionary<char, int> GetAllSymbols()
    {
        return new Dictionary<char, int>(romanValues);
    }

    public static string GetValueDescription(char symbol)
    {
        return symbolDescriptions.TryGetValue(char.ToUpper(symbol), out string? description)
            ? description
            : "Symbole inconnu";
    }

    public static int ConvertRomanToArabicNumbers(string? romanValue)
    {
        if (string.IsNullOrWhiteSpace(romanValue))
            throw new ArgumentException("Le nombre ne peut pas être vide");

        string upperRomanValue = romanValue.ToUpper();
        int result = 0;

        for (int i = 0; i < upperRomanValue.Length; i++)
        {
            if (!romanValues.TryGetValue(upperRomanValue[i], out int currentValue))
                throw new ArgumentException($"Caractère invalide trouvé: {upperRomanValue[i]}");

            if (i < upperRomanValue.Length - 1)
            {
                if (!romanValues.TryGetValue(upperRomanValue[i + 1], out int nextValue))
                    throw new ArgumentException($"Caractère invalide trouvé: {upperRomanValue[i + 1]}");

                if (currentValue < nextValue)
                {
                    result += (nextValue - currentValue);
                    i++;
                    continue;
                }
            }

            result += currentValue;
        }

        if (result > 1000000)
            throw new ArgumentException("La valeur dépasse le maximum autorisé (1 million)");

        return result;
    }
}