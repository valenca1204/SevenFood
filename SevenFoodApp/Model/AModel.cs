using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenFoodApp.Model
{
    public abstract class AModel
    {
        public int Id { get; set; }

        public AModel(int id) { 
            this.Id = id;
        }
    }
}
