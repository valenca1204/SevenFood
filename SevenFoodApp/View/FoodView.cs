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
                string description = Console.ReadLine() ?? "Nome não Informado";

                Console.Write("Preço: ");
                double price = double.Parse(Console.ReadLine() ?? "0.0");

                Console.Write("Descrição: ");
                int idRestaurant = int.Parse(Console.ReadLine() ?? "0");


                if (this.controller.Add(description, price, idRestaurant))
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
            throw new NotImplementedException();
        }

        public void ShowAll()
        {
            throw new NotImplementedException();
        }

        public void ShowById()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
