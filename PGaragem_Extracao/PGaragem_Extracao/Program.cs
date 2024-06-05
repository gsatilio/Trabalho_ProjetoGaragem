using Controllers;
using Models;
using System.Configuration;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

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
            var xml = new XElement("Root");
            foreach (var item in carFalse.CarServiceTable)
            {
                xml.Add(item.Car.GetXMLDocument());
            }
            writer.WriteLine(xml);
            writer.Close();
        }
        // Carros por Cor
        using (var writer = new StreamWriter(ConfigurationManager.ConnectionStrings["XMLFileOutputColor"].ConnectionString))
        {
            var xml = new XElement("Root");
            foreach (var item in carColor.Car)
            {
                xml.Add(item.GetXMLDocument());
            }
            writer.WriteLine(xml);
            writer.Close();
        }
        // Carros por Ano
        using (var writer = new StreamWriter(ConfigurationManager.ConnectionStrings["XMLFileOutputYear"].ConnectionString))
        {
            var xml = new XElement("Root");
            foreach (var item in carYear.Car)
            {
                xml.Add(item.GetXMLDocument());
            }
            writer.WriteLine(xml);
            writer.Close();
        }
    }
}