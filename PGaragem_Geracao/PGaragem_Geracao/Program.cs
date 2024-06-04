using Models;

internal class Program
{
    private static void Main(string[] args)
    {
        int opt = -1;
        Console.WriteLine("Geração Massa de Dados");

        do
        {
            Console.WriteLine("Digite 0 para uma lista de carros nacionais e 1 para carros especiais.");
            opt = int.Parse(Console.ReadLine());
        } while (opt != 0 && opt != 1);
        CarCreator.GenerateCarJSONFile(opt);
    }
}