using SevenFoodApp.Controller;
using SevenFoodApp.Interfaces;
using SevenFoodApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.View
{
    internal class FoodView : IView
    {
        int small = (int)Enums.ColumnSize.SMALL;
        int medium = (int)Enums.ColumnSize.MEDIUM;
        int large = (int)Enums.ColumnSize.LARGE;

        FoodController controller = new FoodController();

        public void Add()
        {
            try
            {
                Console.WriteLine("CADASTRAR NOVA COMIDA\n");
                Console.Write("Descrição: ");
                string description = Please.ConsoleRead() ?? "Nome não Informado";

                Console.Write("Preço: ");
                double price = double.Parse(Please.ConsoleRead() ?? "0,0");

                Console.Write("Restaurante: ");
                int idRestaurant = int.Parse(Please.ConsoleRead() ?? "0");


                if (this.controller.Add(description, price, idRestaurant))
                    Console.WriteLine("Comida Cadastrada com sucesso.");
                else
                    Console.WriteLine(Please.GetMessageGenericError());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Remove()
        {
            Console.WriteLine("PESQUISAR PELO ID");
            Console.Write("Nº ID: ");
            string? idString = Please.ConsoleRead();
            int id = 0;

            if (idString != null)
            {
                int v = int.Parse(idString);
                id = v;
            }

            if (controller.remove(id))
                Console.WriteLine("Comida removida com sucesso.");
            else
                Console.WriteLine(Please.GetMessageGenericError());
        }

        public void ShowAll()
        {
            this.ShowTitle();
            var objs = controller.getAll();

            if (objs != null && objs.Count() > 0)
            {
                foreach (Dictionary<string, string> obj in objs)
                {
                    this.ShowInLine(obj);
                }
            }
        }

        public void ShowById()
        {
            Console.WriteLine("PESQUISAR PELO ID");
            Console.Write("Nº ID: ");
            string? idString = Please.ConsoleRead();
            int id = 0;

            if (idString != null)
            {
                int v = int.Parse(idString);
                id = v;
            }

            var obj = controller.getById(id);

            if (obj != null)
            {
                this.Show(obj);
            }
            else
            {
                Console.WriteLine($"Comida não existe para o id {id}");
            }
        }

        public void Show(Dictionary<string, string> obj)
        {
            if (obj != null)
            {
                Console.WriteLine("CADASTRO DA COMIDA\n");
                Console.WriteLine($"Restaurante: {obj["restaurant"]}");
                Console.WriteLine($"Id         : {obj["id"]}");
                Console.WriteLine($"Descrição  : {obj["description"]}");
                Console.WriteLine($"Preço      : {obj["price"]}");
                Console.WriteLine($"Disponível : {obj["status"]}");
            }

        }

        private void ShowInLine(Dictionary<string, string> obj)
        {
            Console.Write($"{obj["id"].ToString().PadRight(this.small)}");
            Console.Write($"{obj["description"].PadRight(this.large)[..(this.large - 1)]} ");
            Console.Write($"{obj["price"].PadRight(this.small)}");
            Console.Write($"{obj["status"].PadRight(this.medium)}");
            Console.Write($"{obj["restaurant"].PadRight(this.medium)}");
            Console.WriteLine("");
        }

        private void ShowTitle()
        {
            int totalSize = this.small*2 + (this.medium * 2) + this.large;
            Console.WriteLine($"".PadRight(totalSize, '-'));
            Console.Write($"ID".PadRight(this.small));
            Console.Write($"DESCRIPTION".PadRight(this.large));
            Console.Write($"PREÇO".PadRight(this.small));
            Console.Write($"DISPONÍVEL".PadRight(this.medium));
            Console.Write($"RESTAURANTE".PadRight(this.medium));
            Console.WriteLine($"\n--".PadRight(totalSize, '-'));
        }

        public void Update()
        {
            try
            {
                Console.WriteLine("PESQUISAR PELO ID");
                Console.Write("Nº ID: ");
                string? idString = Please.ConsoleRead();
                int id = 0;

                if (idString != null)
                {
                    int v = int.Parse(idString);
                    id = v;
                }

                Dictionary<string, string>? obj = controller.getById(id);

                if (obj != null)
                {
                    this.Show(obj);

                    Console.WriteLine("ATUALIZE OS DADOS DA COMIDA");
                    Console.Write("Descrição: ");
                    string description = Please.ConsoleRead() ?? "";
                    description = description == "" ? obj["description"] : description;

                    Console.Write("Preço: (Formato 0,00)");
                    string priceString = Please.ConsoleRead() ?? "";
                    priceString = priceString == "" ? obj["price"] : priceString;
                    double price = default;

                    try
                    {
                        price = double.Parse(priceString);
                    }
                    catch
                    {
                        throw new Exception("Preço no formato errado, Tente novamente");
                    }

                    int idRestaurant = int.Parse(obj["idRestaurant"]);

                    Console.Write("Disponível: (1 - Sim | 0 - Não)");
                    string active = Please.ConsoleRead()!;
                    bool status;
                    switch (active)
                    {
                        case "":
                            status = Please.TranslateToBool(obj["status"]); break;
                        case "1":
                            status = true; break;
                        default:
                            status = false; break;
                    }

                    if (controller.update(id, description, idRestaurant, price, status))
                        Console.WriteLine("Comida Atualizado com sucesso.");
                    else
                        Console.WriteLine(Please.GetMessageGenericError());
                }
                else
                {
                    Console.WriteLine($"Comida não existe para o id {id}");
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToString()); 
            }
        }
    }
}
