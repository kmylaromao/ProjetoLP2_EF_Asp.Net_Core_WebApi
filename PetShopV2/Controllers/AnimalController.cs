using Petshop.Model;
using Petshop.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;

namespace Petshop.Controller
    {
        [ApiController]
        [Route("/api/[controller]")]
        public class AnimalController : ControllerBase
        {
            private readonly IAnimalRepository _animalRepository;
            public AnimalController(IAnimalRepository animalRepository)
            {
                _animalRepository = animalRepository;
            }


        [HttpGet]
        [Produces(typeof(Animal))]
        public IActionResult GetAll()
        {
            var animais = _animalRepository.GetAll();
            if (animais.Count() == 0)
                return NoContent();
            return Ok(animais);
        }
            

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _animalRepository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public IActionResult Create(Animal animal)
        {   
            if (animal == null)
            {
                return BadRequest("Objeto não pode ser null");
            }
          
            return Ok(value: _animalRepository.Create(animal));

        } 


        [HttpPut("{id}")]
        public IActionResult Update(Animal animal, int id)
        {
            if(animal == null)
            {
                return BadRequest();
            }

            _animalRepository.Update(animal,id);
            return NoContent();

        }
        [HttpDelete ("{id}")]
        public IActionResult Delete(int id)
        {
            
            var entity = _animalRepository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }

            _animalRepository.Delete(id);
            return Ok();
            
        }
       

    }
}