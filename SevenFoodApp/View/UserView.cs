using System;
using SevenFoodApp.Controller;
using SevenFoodApp.Dto;

namespace SevenFoodApp.View
{
    public class UserView
    {
        private UserController controller = new UserController();

        public void CadastrarUsuario()
        {
            Console.WriteLine("Digite seu nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite seu email:");
            string email = Console.ReadLine();

            var userRequest = new UserRequestDTO
            {
                Nome = nome,
                Email = email
            };

            UserResponseDTO response = controller.CadastrarUser(userRequest);

            Console.WriteLine($"Olá {response.Nome}, senha senha é {response.SenhaGerada}");
        }
    }
}