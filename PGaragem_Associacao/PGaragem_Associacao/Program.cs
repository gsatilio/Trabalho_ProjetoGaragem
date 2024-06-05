using Controllers;
using Models;
using Services;
using System;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        int menu = -1;
        ServiceController serviceController = new();
        CarController carController = new();
        CarServiceTableController carServiceTableController = new();
        Console.WriteLine("Associação de Dados");

        do
        {
            Console.WriteLine("1 - Criar Serviço");
            Console.WriteLine("2 - Associar Serviço a um Carro");
            Console.WriteLine("3 - Alterar situação de um Carro x Serviço");
            Console.WriteLine("0 - Sair");
            menu = int.Parse(Console.ReadLine());
            switch (menu)
            {
                case 1:
                    CreateService();
                    break;
                case 2:
                    AssociateService();
                    break;
                case 3:
                    RetrieveCarService();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            Console.ReadKey();
        } while (menu != 0);


        void CreateService()
        {
            Console.WriteLine("Informe a descrição do Serviço:");
            string dc = Console.ReadLine();
            Service service = new Service { Description = dc };
            var result = serviceController.InsertService(service);
            if (result == 0)
            {
                Console.WriteLine("Erro ao inserir serviço.");
            }
            else
            {
                service.Id = result;
                Console.WriteLine($"Serviço criado: {result} - {dc}");
            }
        }

        Car RetrieveCar()
        {
            CarList carList = new();
            Console.WriteLine("Lista de Carros cadastrados:");
            carList = carController.RetrieveCar();
            int index = 1;
            int opt = 0;

            Console.WriteLine(
            $"[Id]".PadRight(10) +
            $"[Placa]".PadRight(10) +
            $"[Nome]".PadRight(20) +
            $"[Ano Modelo]".PadRight(12) +
            $"[Ano Fabricação]".PadRight(13) +
            $"[Cor]".PadRight(20));
            foreach (var item in carList.Car)
            {
                Console.WriteLine(
                 $"{index}".PadRight(10) +
                 $"({item.LicensePlate})".PadRight(10) +
                 $"{item.Name}".PadRight(20) +
                 $"{item.ModelYear}".PadRight(12) +
                 $"{item.FabricationYear}".PadRight(16) +
                 $"{item.Color}".PadRight(20));
                index++;
            }

            do
            {
                Console.WriteLine("Escolha o Id do carro desejado:");
                opt = int.Parse(Console.ReadLine());
            } while (opt <= 0 || opt > carList.Car.Count());
            Car cr = carList.Car[opt - 1];
            return cr;
        }
        Service RetrieveService()
        {
            int opt = 0;
            int index = 1;
            ServiceList serviceList = new ServiceList();

            Console.WriteLine("Lista de Serviços disponíveis:");
            serviceList = serviceController.RetrieveService();

            Console.WriteLine(
            $"[Id]".PadRight(10) +
            $"[Serviço]".PadRight(10));
            foreach (var item in serviceList.Service)
            {
                Console.WriteLine(
                 $"{index}".PadRight(10) +
                 $"{item.Description}".PadRight(10));
                index++;
            }
            do
            {
                Console.WriteLine("Informe o Id do serviço desejado:");
                opt = int.Parse(Console.ReadLine());
            } while (opt <= 0 || opt > serviceList.Service.Count());
            Service sv = serviceList.Service[opt - 1];
            return sv;
        }

        void AssociateService()
        {
            Car cr = RetrieveCar();
            Service sv = RetrieveService();
            CarServiceTable cs = new CarServiceTable { Car = cr, Service = sv, Status = true };

            Console.WriteLine(cr + " " + sv);
            carServiceTableController.InsertCarServiceTable(cs);
        }


        CarServiceTable RetrieveCarService()
        {
            int opt = 0;
            int index = 1;
            CarServiceTableList csList = new();
            csList = carServiceTableController.RetrieveCarServiceTable();

            Console.WriteLine("Lista de Carros x Serviços atuais:");
            Console.WriteLine(
            $"[Id]".PadRight(10) +
            $"[Placa]".PadRight(10) +
            $"[Serviço]".PadRight(10) +
            $"[Situacao]".PadRight(10));
            foreach (var item in csList.CarServiceTable)
            {
                Console.WriteLine(
                 $"{index}".PadRight(10) +
                 $"{item.Car.LicensePlate}".PadRight(10) +
                 $"{item.Service.Description}".PadRight(10) +
                 $"{item.Status}".PadRight(10));
                index++;
            }
            do
            {
                Console.WriteLine("Informe o Id que deseja alterar a situação:");
                opt = int.Parse(Console.ReadLine());
            } while (opt <= 0 || opt > csList.CarServiceTable.Count());
            CarServiceTable csv = csList.CarServiceTable[opt - 1];
            csv.Status = !csv.Status;
            carServiceTableController.ChangeStatusCarServiceTable(csv);
            return csv;
        }
    }
}