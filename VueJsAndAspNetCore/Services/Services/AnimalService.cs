using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Classes;

namespace Services.Services
{
    public interface IAnimalService
    {
        Response Add(Animal animal);
        void Remove(string name);
        IEnumerable<Animal> Get();
    }
    public class AnimalService: IAnimalService
    {
        public Response Add(Animal animal)
        {
           return  DbService.Add(animal);
        }

        public void Remove(string name)
        {
            DbService.Remove(name);
        }

        public IEnumerable<Animal> Get()
        {
            return DbService.Get();
        }
    }
}
