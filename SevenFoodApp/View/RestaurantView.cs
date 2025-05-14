using SevenFoodApp.Controller;
using SevenFoodApp.Interfaces;
using SevenFoodApp.Model;
using SevenFoodApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SevenFoodApp.Util.Enums;

namespace SevenFoodApp.View
{
    internal class RestaurantView : IView
    {
        int small = (int)Enums.ColumnSize.SMALL;
        int medium = (int)Enums.ColumnSize.MEDIUM;
        int large = (int)Enums.ColumnSize.LARGE;
        RestaurantController controller = new RestaurantController();
        public void Add()
        {
            try
            {
                Console.WriteLine("CADASTRAR NOVO RESTAURANTE\n");
                Console.Write("Nome: ");
                string name = Console.ReadLine() ?? "Nome não Informado";

                if (this.controller.Add(name))
                    Console.WriteLine("Restaurante Cadastrado com sucesso.");
                else
                    Console.WriteLine("Algo de errado não está certo :(");
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
            string? idString = Console.ReadLine();
            int id = 0;

            if (idString != null)
            {
                int v = int.Parse(idString);
                id = v;
            }

            if (controller.remove(id))
                Console.WriteLine("Restaurante removido com sucesso.");
            else
                Console.WriteLine("Algo de errado não está certo :(");
        }

        public void ShowById()
        {
            Console.WriteLine("PESQUISAR PELO ID");
            Console.Write("Nº ID: ");
            string? idString = Console.ReadLine();
            int id = 0;

            if (idString != null)
            {
                int v = int.Parse(idString);
                id = v;
            }

            Restaurant? obj = controller.getById(id);

            if (obj != null)
            {
                this.Show(obj);
            }
            else
            {
                Console.WriteLine($"Usuário não existe para o id {id}");
            }
        }
        public void Show(Restaurant obj)
        {
            if (obj != null)
            {
                Console.WriteLine("CADASTRO DO USUÁRIO\n");
                Console.WriteLine($"Id   : {obj.Id}");
                Console.WriteLine($"Nome : {obj.Name}");
                Console.WriteLine($"Ativo: {obj.Active}");
            }

        }

        public void ShowAll()
        {
            this.ShowTitle();
            foreach (Restaurant restaurant in controller.getAll())
            {
                this.ShowInLine(restaurant);
            }
        }

        public void Update()
        {
            Console.WriteLine("PESQUISAR PELO ID");
            Console.Write("Nº ID: ");
            string? idString = Console.ReadLine();
            int id = 0;

            if (idString != null)
            {
                int v = int.Parse(idString);
                id = v;
            }

            Restaurant? obj = controller.getById(id);

            if (obj != null)
            {
                this.Show(obj);

                Console.WriteLine("ATUALIZE OS DADOS DO USUÁRIO");
                Console.Write("Nome: ");
                string name = Console.ReadLine() ?? "";

                name = name == "" ? obj!.Name : name;

                Console.Write("Status: (1 - Ativo | 0 - Inativo)");
                string active = Console.ReadLine()!;
                bool status;
                switch (active)
                {
                    case "":
                        status = obj.Active; break;
                    case "1":
                        status = true; break;
                    default:
                        status = false; break;
                }

                if (controller.update(id, name, status))
                    Console.WriteLine("Usuario Atualizado com sucesso.");
                else
                    Console.WriteLine("Erro de errado não está certo :(");
            }
            else
            {
                Console.WriteLine($"Usuário não existe para o id {id}");
            }
        }

        private void ShowInLine(Restaurant restaurant)
        {
            Console.Write($"{restaurant.Id.ToString().PadRight(this.small)}");
            Console.Write($"{restaurant.Name.PadRight(this.large)[..(this.large - 1)]} ");
            Console.Write($"{restaurant.Active.ToString().PadRight(this.medium)}");
            Console.WriteLine("");
        }

        private void ShowTitle()
        {
            int totalSize = this.small + (this.medium * 2) + this.large;
            Console.WriteLine($"".PadRight(totalSize, '-'));
            Console.Write($"ID".PadRight(this.small));
            Console.Write($"NOME".PadRight(this.large));
            Console.WriteLine($"ATIVO".PadRight(this.medium));
            Console.WriteLine($"".PadRight(totalSize, '-'));
        }
    }
}
