using Controllers;
using Models;
using System.Configuration;
using System.Reflection.PortableExecutable;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Extração de Dados");

        CarController carcontroller = new();
        CarServiceTableController carServiceTableController = new();
        var carColor = carcontroller.RetrieveCarByColor("vermelho");
        var carYear = carcontroller.RetrieveCarByYear(2010,2011);
        var carFalse = carServiceTableController.RetrieveCarServiceTableStatus(true);

        // Carros por Status
        using (var writer = new StreamWriter(ConfigurationManager.ConnectionStrings["XMLFileOutputStatus"].ConnectionString))
        {
            foreach (var item in carFalse.CarServiceTable)
            {
                writer.WriteLine(item.Car.GetXMLDocument());
            }
            writer.Close();
        }
        // Carros por Cor
        using (var writer = new StreamWriter(ConfigurationManager.ConnectionStrings["XMLFileOutputColor"].ConnectionString))
        {
            foreach (var item in carColor.Car)
            {
                writer.WriteLine(item.GetXMLDocument());
            }
            writer.Close();
        }
        // Carros por Ano
        using (var writer = new StreamWriter(ConfigurationManager.ConnectionStrings["XMLFileOutputYear"].ConnectionString))
        {
            foreach (var item in carYear.Car)
            {
                writer.WriteLine(item.GetXMLDocument());
            }
            writer.Close();
        }
    }
}