using Controllers;
using System.Configuration;
internal class Program
{
    private static void Main(string[] args)
    {
        CarController carController = new CarController();
        Console.WriteLine("Ingestão de Dados");

        if (carController.SaveCarDataFromAPI(ConfigurationManager.ConnectionStrings["JSONFileOutput"].ConnectionString))
        {
            Console.WriteLine("Inserção no SQL realizada com sucesso!");
        } else
        {
            Console.WriteLine("Erro na inserção!");
        }

    }
}