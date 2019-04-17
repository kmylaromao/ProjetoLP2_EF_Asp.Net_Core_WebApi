using System.Collections.Generic;
using Petshop.Model;
using MySql.Data.MySqlClient;
using Dapper;
using System;

namespace Petshop.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly string _connectionString;

        public AnimalRepository(string connectionString)
        {
            _connectionString = connectionString;   // Injetando a string de conexão no construtor da classe
        }

        public IEnumerable<Animal> GetAll()
        {
            using(MySqlConnection connection = new MySqlConnection(_connectionString))
            {
            
                return connection.Query<Animal>("SELECT codigo, nome, endereco FROM Animal ORDER BY nome ASC");
            }
        }

        internal static object GetById(int cod)
        {
            throw new NotImplementedException();
        }

        object IAnimalRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public object Create(Animal animal)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Animal animal, int id)
        {
            throw new NotImplementedException();
        }
    }
}