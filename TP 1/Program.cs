namespace TP_1;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            DisplaySymbolGuide();
            
            string? response;
            do
            {
                AskAndConvertRomanValue();
                Console.WriteLine("\nVoulez-vous convertir un autre nombre romain? (O/N)");
                response = Console.ReadLine()?.ToUpper();
            } while (response == "O");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erreur: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Une erreur inattendue s'est produite: {ex.Message}");
        }

        Console.WriteLine("\nProgramme terminé. Appuyez sur une touche pour quitter.");
        Console.ReadKey();
    }

    private static void DisplaySymbolGuide()
    {
        Console.WriteLine("Guide des symboles disponibles :");
        Console.WriteLine("--------------------------------");
        foreach (var symbol in RomanConverter.GetAllSymbols())
        {
            Console.WriteLine($"{symbol.Key} = {RomanConverter.GetValueDescription(symbol.Key)}");
        }
        Console.WriteLine("--------------------------------\n");
    }

    private static void AskAndConvertRomanValue()
    {
        Console.WriteLine("Entrez un nombre romain:");
        string? input = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Vous devez entrer une valeur.");
            return;
        }
        
        int resultat = RomanConverter.ConvertRomanToArabicNumbers(input);
        Console.WriteLine($"La valeur en chiffres arabes est: {resultat:N0}");
    }
}