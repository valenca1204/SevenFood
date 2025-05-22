using SevenFoodApp.Controller;
using SevenFoodApp.Interfaces;
using SevenFoodApp.Model;
using SevenFoodApp.Util;
using static SevenFoodApp.Util.Enums;
using SevenFoodApp.dto;


namespace SevenFoodApp.View
{
    internal class UserView : IView
    {
        private UserController controller = new UserController();

        private UserDto userDto = new UserDto();

        public void Add()
        {
            try
            {
                Console.WriteLine("CADASTRAR NOVO USUÁRIO\n");
                Console.Write("Nome: ");
                string name = Please.ConsoleRead() ?? "Nome não Informado";
                userDto.Name = name;
                userDto.Type = TYPE_USER.Client;

                if (this.controller.Add(userDto))
                    Console.WriteLine($"{userDto.Name} , sua senha é {userDto.Senha}");
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
                Console.WriteLine("Usuario Removido com sucesso.");
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
                Console.WriteLine($"Usuário não existe para o id {id}");
            }
        }
        public void Show(Dictionary<string, string> obj)
        {
            if (obj != null)
            {
                Console.WriteLine("CADASTRO DO USUÁRIO\n");
                Console.WriteLine($"Id    : {obj["id"]}");
                Console.WriteLine($"Nome  : {obj["name"]}");
                Console.WriteLine($"Senha : {obj["password"]}");
                Console.WriteLine($"Tipo  : {obj["type"]}");
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

                Console.Write("Senha: ");
                string password = Please.ConsoleRead() ?? "";
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
            Console.Write($"{obj["id"].ToString().PadRight((int)SIZE.FIVE)}");
            Console.Write($"{obj["name"].PadRight((int)SIZE.THIRTY)[..((int)SIZE.THIRTY - 1)]} ");
            Console.Write($"{obj["password"].PadRight((int)SIZE.FIFTEEN)}");
            Console.Write($"{obj["type"].ToString().PadRight((int)SIZE.TWENTY)}");
            Console.WriteLine("");
        }

        private void ShowTitle()
        {
            int totalSize = (int)SIZE.FIVE + (int)SIZE.FIFTEEN + (int)SIZE.THIRTY + (int)SIZE.TWENTY;
            Console.WriteLine($"".PadRight(totalSize, '-'));
            Console.Write($"ID".PadRight((int)SIZE.FIVE));
            Console.Write($"NOME".PadRight((int)SIZE.THIRTY));
            Console.Write($"SENHA".PadRight((int)SIZE.FIFTEEN));
            Console.Write($"TIPO".PadRight((int)SIZE.TWENTY));
            Console.WriteLine($"\n".PadRight(totalSize, '-'));
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
                type = Please.ConsoleRead()!;
                is_valid = options.Contains(type);

                if (!is_valid)
                    Console.WriteLine(Please.GetMessageInvalidOption(true));

            } while (!is_valid);

            return (TYPE_USER)int.Parse(type!);
        }
    }
}
