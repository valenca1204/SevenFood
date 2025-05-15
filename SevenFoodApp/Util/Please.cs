using SevenFoodApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.Util
{
    public class Please
    {
        public static void StartDataBase()
        {
            FileRepository.StartFiles();
        }
        public static int GetNextId()
        {
            return FileRepository.getLastId() + 1;
        }
    }
}
