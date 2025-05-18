using SevenFoodApp.Interfaces;
using SevenFoodApp.Repository;
using SevenFoodApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SevenFoodApp.Util.Enums;

namespace SevenFoodApp.Model
{
    public abstract class ARepository<T> : IRepository<T> where T : AModel
    {
        private FileRepository fileRepository;

        public ARepository(CONTEXT context)
        {
            this.fileRepository = new FileRepository(context);
        }


        public T? GetById(int id)
        {
            string? obj = fileRepository.GetById(id);
            
            if (obj != null)
            {
                return this.StringToObject(obj!);
            }
            return default;
        }

        public List<T> GetAll()
        {
            List<T> list = new List<T>();
            try
            {
                string[] objects = fileRepository.GetAll();                
                foreach (string obj in objects)
                {
                    T? model = this.StringToObject(obj);
                    if (model != null)
                        list.Add(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return list;
        }

        public bool Update(T entity)
        {
            return fileRepository.Update(entity.Id, ToString(entity));
        }

        public bool Delete(int id)
        {
            return fileRepository.Delete(id);
        }

        public bool Insert(T entity)
        {
            return fileRepository.Insert(entity.Id, ToString(entity));
        }       

        public abstract T? StringToObject(string str);
        public abstract string ToString(T entity);


    }
}
