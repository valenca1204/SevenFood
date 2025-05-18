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
                string name = Please.ConsoleRead() ?? "Nome não Informado";

                if (this.controller.Add(name))
                    Console.WriteLine("Restaurante Cadastrado com sucesso.");
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
                Console.WriteLine("Restaurante removido com sucesso.");
            else
                Console.WriteLine(Please.GetMessageGenericError());
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
                Console.WriteLine($"Restaurante não existe para o id {id}");
            }
        }
        public void Show(Dictionary<string, string> obj)
        {
            if (obj != null)
            {
                Console.WriteLine("CADASTRO DO RESTAURANTE\n");
                Console.WriteLine($"Id   : {obj["id"]}");
                Console.WriteLine($"Nome : {obj["name"]}");
                Console.WriteLine($"Ativo: {obj["active"]}");
            }

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

        public void Update()
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

                Console.WriteLine("ATUALIZE OS DADOS DO USUÁRIO");
                Console.Write("Nome: ");
                string name = Please.ConsoleRead() ?? "";
                name = name == "" ? obj["name"] : name;

                Console.Write("Status: (1 - Ativo | 0 - Inativo)");
                string active = Please.ConsoleRead()!;
                bool status;
                switch (active)
                {
                    case "":
                        status = Please.TranslateToBool(obj["active"]); break;
                    case "1":
                        status = true; break;
                    default:
                        status = false; break;
                }

                if (controller.update(id, name, status))
                    Console.WriteLine("Restaurante Atualizado com sucesso.");
                else
                    Console.WriteLine(Please.GetMessageGenericError());
            }
            else
            {
                Console.WriteLine($"Restaurante não existe para o id {id}");
            }
        }

        private void ShowInLine(Dictionary<string, string> obj)
        {
            Console.Write($"{obj["id"].ToString().PadRight(this.small)}");
            Console.Write($"{obj["name"].PadRight(this.large)[..(this.large - 1)]} ");
            Console.Write($"{obj["active"].PadRight(this.medium)}");
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
