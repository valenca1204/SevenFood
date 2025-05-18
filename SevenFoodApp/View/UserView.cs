using SevenFoodApp.Controller;
using SevenFoodApp.Interfaces;
using SevenFoodApp.Model;
using SevenFoodApp.Util;
using static SevenFoodApp.Util.Enums;


namespace SevenFoodApp.View
{
    internal class UserView : IView
    {
        int small = (int)Enums.ColumnSize.SMALL;
        int medium = (int)Enums.ColumnSize.MEDIUM;
        int large = (int)Enums.ColumnSize.LARGE;

        private UserController controller = new UserController();

        public void Add()
        {
            try
            {
                Console.WriteLine("CADASTRAR NOVO USUÁRIO\n");
                Console.Write("Nome: ");
                string name = Console.ReadLine() ?? "Nome não Informado";

                if (this.controller.Add(name, TYPE_USER.Client))
                    Console.WriteLine("Usuario Cadastrado com sucesso.");
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
            string? idString = Console.ReadLine();
            int id = 0;

            if (idString != null)
            {
                int v = int.Parse(idString);
                id = v;
            }

            if (controller.remove(id))
                Console.WriteLine("Usuario Removido com sucesso.");
            else
                Console.WriteLine(Please.GetMessageGenericError());
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

            var obj = controller.getById(id);

            if (obj != null)
            {
                this.Show(obj);
            }
            else
            {
                Console.WriteLine($"Usuário não existe para o id {id}");
            }
        }
        public void Show(Dictionary<string, string> obj)
        {
            if (obj != null)
            {
                Console.WriteLine("CADASTRO DO USUÁRIO\n");
                Console.WriteLine($"Id   : {obj["id"]}");
                Console.WriteLine($"Nome : {obj["name"]}");
                Console.WriteLine($"Senha: {obj["password"]}");
                Console.WriteLine($"Tipo: {obj["type"]}");
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
            string? idString = Console.ReadLine();
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
                string name = Console.ReadLine() ?? "";

                name = name == "" ? obj["name"] : name;

                Console.Write("Senha: ");
                string password = Console.ReadLine() ?? "";
                password = password == "" ? obj["password"] : password;

                TYPE_USER type = this.getTypeUser();


                if (controller.update(id, name, password, type))

                    Console.WriteLine("Usuario Atualizado com sucesso.");
                else
                    Console.WriteLine(Please.GetMessageGenericError());
            }
            else
            {
                Console.WriteLine($"Usuário não existe para o id {id}");
            }
        }

        private void ShowInLine(Dictionary<string, string> obj)
        {
            Console.Write($"{obj["id"].ToString().PadRight(this.small)}");
            Console.Write($"{obj["name"].PadRight(this.large)[..(this.large - 1)]} ");
            Console.Write($"{obj["password"].PadRight(this.medium)}");
            Console.Write($"{obj["type"].ToString().PadRight(this.medium)}");
            Console.WriteLine("");
        }

        private void ShowTitle()
        {
            int totalSize = this.small + (this.medium * 2) + this.large;
            Console.WriteLine($"".PadRight(totalSize, '-'));
            Console.Write($"ID".PadRight(this.small));
            Console.Write($"NOME".PadRight(this.large));
            Console.Write($"SENHA".PadRight(this.medium));
            Console.WriteLine($"TIPO".PadRight(this.medium));
            Console.WriteLine($"".PadRight(totalSize, '-'));
        }



        private TYPE_USER getTypeUser()
        {
            string[] options = ["1", "2"];
            bool is_valid = false;
            string type;
            Console.WriteLine("TIPO DE USUÁRIO: ");
            Console.WriteLine("1 - Dono de Restaurante");
            Console.WriteLine("2 - Cliente");
            do
            {
                Console.Write("Tipo: ");
                type = Console.ReadLine()!;
                is_valid = options.Contains(type);

                if (!is_valid)
                    Console.WriteLine(Please.GetMessageInvalidOption(true));

            } while (!is_valid);

            return (TYPE_USER)int.Parse(type!);
        }
    }
}
