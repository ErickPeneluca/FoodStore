using FoodStore.Models;
using FoodStore.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository _repository;

        public FoodController(IFoodRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var foods = await _repository.FindFoods();
            return foods.Any()
                ? Ok(foods)
                : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var food = await _repository.FindFoodById(id);
            return food != null
                ? Ok(food)
                : NotFound("Foods not found");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Food food)
        {
            _repository.AddFood(food);
            return await _repository.SaveChangesAsync()
                ? Ok(food)
                : BadRequest("Error to create");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Food food)
        {
            var foodDb = await _repository.FindFoodById(id);
            if (foodDb == null) return NotFound("Food not found");

            foodDb.Name = food.Name ?? foodDb.Name;

            _repository.UpdateFood(foodDb);

            return await _repository.SaveChangesAsync()
               ? Ok("Food edit sucessefuly")
               : BadRequest("Error to save food");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var foodDb = await _repository.FindFoodById(id);
            if (foodDb == null) return NotFound("Food not found");

            _repository.DeleteFood(foodDb);

            return await _repository.SaveChangesAsync()
            ? Ok("Food deleted sucessefuly")
            : BadRequest("Error to delete food");

        }
    }
}
