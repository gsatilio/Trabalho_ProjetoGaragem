using Newtonsoft.Json;
using System.Configuration;

namespace Models
{
    public class CarCreator
    {
        public CarCreator()
        {

        }

        public static void GenerateCarJSONFile(int opt)
        {
            CarList carList = new CarList();
            carList.Car = new List<Car>();

            for (int i = 0; i < 30; i++)
            {
                int modYear = new Random().Next(1980, 2024);
                carList.Car.Add(new Car
                {
                    LicensePlate = GenerateLicensePlate(),
                    Color = GenerateCarColorList().OrderBy(s => Guid.NewGuid()).First(),
                    FabricationYear = modYear - 1,
                    ModelYear = modYear,
                    Name = GenerateCarNameList(opt).OrderBy(s => Guid.NewGuid()).First()
                });
            }

            using (var writer = new StreamWriter(ConfigurationManager.ConnectionStrings["JSONFileOutput"].ConnectionString))
            {
                writer.WriteLine(JsonConvert.SerializeObject(carList, Formatting.Indented));
                writer.Close();
            }

            Console.WriteLine("\nCarros gerados com sucesso! Lista de carros:\n");
            foreach (var item in carList.Car)
            {
                Console.WriteLine(item);
            }
        }

        static string GenerateLicensePlate()
        {
            string format = "AAA0A00";
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            char[] result = new char[7];
            for (int i = 0; i < 7; i++)
            {
                switch (format[i])
                {
                    case 'A':
                        result[i] = letters[new Random().Next(letters.Length)];
                        break;
                    case '0':
                        result[i] = numbers[new Random().Next(numbers.Length)];
                        break;
                    default:
                        result[i] = format[i];
                        break;
                }
            }
            return new string(result);
        }

        static List<string> GenerateCarNameList(int opt)
        {
            List<string> CarNameList;
            if (opt == 0)
            {
                CarNameList = new List<string>
                {"Volkswagen Fusca",
                "Chevrolet Opala",
                "Fiat Uno",
                "Volkswagen, Gol",
                "Fiat Palio",
                "Ford Ka",
                "Chevrolet Celta",
                "Volkswagen Santana",
                "Chevrolet Corsa",
                "Fiat Strada",
                "Ford Fiesta",
                "Volkswagen Voyage",
                "Fiat Siena",
                "Chevrolet Prisma",
                "Volkswagen Saveiro",
                "Fiat Punto",
                "Ford Focus",
                "Renault Sandero",
                "Chevrolet Vectra",
                "Volkswagen Brasília",
                "Fiat 147",
                "Chevrolet Chevette",
                "Volkswagen Kombi",
                "Fiat Fiorino",
                "Ford Escort",
                "Chevrolet Monza",
                "Volkswagen Fox",
                "Fiat Tempra",
                "Ford Maverick",
                "Chevrolet Agile"
                };
            }
            else
            {
                CarNameList = new List<string>
                {"SambaSprint",
                 "AmazoniaAdventurer",
                 "CarnavalCruiser",
                 "BossaNovaBolt",
                 "CopacabanaCruiser",
                 "RioRacer",
                 "IpanemaInterceptor",
                 "CapoeiraCruiser",
                 "SertãoSpeedster",
                 "PantanalPioneer",
                 "CariocaChallenger",
                 "BahiaBlast",
                 "PampasPacer",
                 "ParatyProwler",
                 "PantanalProwess",
                 "RecifeRapid",
                 "FortalezaFlyer",
                 "BrasíliaBolt",
                 "MaracanãMach",
                 "SerraSprinter",
                 "CachoeiraCruiser",
                 "TropicanaThunder",
                 "CaipirinhaCruiser",
                 "GuaranaGlide",
                 "IlhaBelEagle",
                 "AracajuAce",
                 "ManausMaverick",
                 "AçaiAdventurer",
                 "CarnaúbaCruiser",
                 "PãoDeAçúcarPilot"
                };
            }
            return CarNameList;
        }

        static List<string> GenerateCarColorList()
        {
            List<string> carColorList = new List<string>
            {"Vermelho",
            "Azul",
            "Preto",
            "Vermelho",
            "Branco",
            "Laranja"
            };
            return carColorList;
        }
    }
}
