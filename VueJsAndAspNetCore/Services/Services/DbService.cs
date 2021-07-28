using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Classes;

namespace Services.Services
{
    public static class DbService
    {
        public static IDictionary<string, Animal> db = new Dictionary<string, Animal>();

        public static Response Add(Animal animal)
        {
            var response = new Response();
            try
            {
                db.Add(animal.name, animal);
                response.Status = TransactionStatus.Succeeded;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                response.Status = TransactionStatus.Failed;
                response.FailedMsg = e.ToString();
            }

            return response;
        }

        public static void Remove(string name)
        {
            db.Remove(name);
        }

        public static IEnumerable<Animal> Get()
        {
            return db?.Values.AsEnumerable();
        }
        
    }
}
