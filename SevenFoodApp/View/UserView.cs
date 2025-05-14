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
                    Console.WriteLine("Erro de errado não está certo :(");
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
                Console.WriteLine("Erro de errado não está certo :(");
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

            User? obj = controller.getById(id);

            if (obj != null)
            {
                this.Show(obj);
            }
            else
            {
                Console.WriteLine($"Usuário não existe para o id {id}");
            }
        }
        public void Show(User obj)
        {
            if (obj != null)
            {
                Console.WriteLine("CADASTRO DO USUÁRIO\n");
                Console.WriteLine($"Id   : {obj.Id}");
                Console.WriteLine($"Nome : {obj.Name}");
                Console.WriteLine($"Senha: {obj.Password}");
            }

        }

        public void ShowAll()
        {
            this.ShowTitle();
            foreach (User user in controller.getAll())
            {
                this.ShowInLine(user);
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

            User? obj = controller.getById(id);

            if (obj != null)
            {
                this.Show(obj);

                Console.WriteLine("ATUALIZE OS DADOS DO USUÁRIO");
                Console.Write("Nome: ");
                string name = Console.ReadLine() ?? "";

                name = name == "" ? obj!.Name : name;

                Console.Write("Seha: ");
                string password = Console.ReadLine() ?? "";
                password = password == "" ? obj!.Password : password;

                TYPE_USER type = this.getTypeUser();


                if (controller.update(id, name, password, type))
                    Console.WriteLine("Usuario Atualizado com sucesso.");
                else
                    Console.WriteLine("Erro de errado não está certo :(");
            }
            else
            {
                Console.WriteLine($"Usuário não existe para o id {id}");
            }
        }

        private void ShowInLine(User user)
        {
            Console.Write($"{user.Id.ToString().PadRight(this.small)}");
            Console.Write($"{user.Name.PadRight(this.large)[..(this.large - 1)]} ");
            Console.Write($"{user.Password.PadRight(this.medium)}");
            Console.Write($"{user.Type.ToString().PadRight(this.medium)}");
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

        public void Login()
        {
            bool canTryLogin = false;
            string? id;
            string? password;
            bool approved = false;
            do
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("|  >>> SEVEN FOOD <<<  |");
                Console.WriteLine("------------------------");
                Console.Write("ID: ");
                id = Console.ReadLine();
                Console.Write("Senha: ");
                password = Console.ReadLine();

                canTryLogin = (id != null) && (password != null);
                if (canTryLogin)
                    approved = controller.Loggin(id!, password!);

                if (!approved)
                    Console.WriteLine("Opa, algo de errado não está certo\nTente novamente");

            } while (canTryLogin && !approved);

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
                    Console.WriteLine("Opção Inválida");

            } while (!is_valid);

            return (TYPE_USER)int.Parse(type!);
        }
    }
}
