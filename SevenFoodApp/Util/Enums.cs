using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.Util
{
    public class Enums
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
        }

        public enum USER : int
        {
            BACK = 0,
            GET_BY_ID = 1,
            GET_ALL = 2,
            INSERT = 3,
            UPDATE = 4,
            DELETE = 5,
        }

        public enum RESTAURANT : int
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
    }
}
