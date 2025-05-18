using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.Util
{
    public static class Enums
    {
        public enum ColumnSize : int
        {
            SMALL = 7,
            MEDIUM = 15,
            LARGE = 30
        }

        public enum CONTEXT : int
        {
            EXIT = 0,
            USER = 1,
            RESTAURANT = 2,
            FOOD = 3,
        }

        public enum ACTION : int
        {
            BACK = 0,
            GET_BY_ID = 1,
            GET_ALL = 2,
            INSERT = 3,
            UPDATE = 4,
            DELETE = 5,
        }

        public enum TYPE_USER : int
        {
            Admin = 0,
            Owner = 1,
            Client = 2,
        }

        public static string Translate(this CONTEXT context)
        {
            switch (context)
            {
                case CONTEXT.USER: return "Úsuário";
                case CONTEXT.RESTAURANT: return "Restaurante";
                case CONTEXT.EXIT: return "Sair";
                default: return "Contexto Inexistente";
            }
        }

        public static string Translate(this ACTION action)
        {
            switch (action)
            {
                case ACTION.BACK: return "Voltar";
                case ACTION.GET_BY_ID: return "Buscar por ID";
                case ACTION.GET_ALL: return "Listar Todos";
                case ACTION.INSERT: return "Cadastrar";
                case ACTION.UPDATE: return "Atualizar";
                case ACTION.DELETE: return "Remover";
                default: return "Ação Inexistente";
            }
        }

        public static string Translate(this TYPE_USER action)
        {
            switch (action)
            {
                case TYPE_USER.Admin: return "Administrador";
                case TYPE_USER.Owner: return "Dono de Restaurante";
                case TYPE_USER.Client: return "Cliente";
                default: return "Ação Inexistente";
            }
        }
    }
}
