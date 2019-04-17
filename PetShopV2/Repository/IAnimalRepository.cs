    using System.Collections.Generic;
    using Petshop.Model;
    namespace Petshop.Repository
    {
        public interface IAnimalRepository
        {
            IEnumerable<Animal> GetAll();
        object GetById(int id);
        object Create(Animal animal);
        void Delete(int id);
        void Update(Animal animal, int id);
    }
    }