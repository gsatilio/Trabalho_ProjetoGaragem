using Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Geração Massa de Dados");
        Console.WriteLine("Digite 0 para uma lista de carros nacionais e 1 para carros especiais.");
        int opt = int.Parse(Console.ReadLine());
        CarCreator.GenerateCarJSONFile(opt);
    }
}