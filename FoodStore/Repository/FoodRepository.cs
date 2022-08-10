using FoodStore.Data;
using Microsoft.EntityFrameworkCore;
using FoodStore.Models;
using FoodStore.Repository.Interfaces;

namespace FoodStore.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly FoodContext _context;

        public FoodRepository(FoodContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Food>> FindFoods()
        {
            return await _context.foods.ToListAsync();
        }

        public async Task<Food> FindFoodById(int id)
        {
            return await _context.foods.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void AddFood(Food food)
        {
            _context.Add(food);
        }

        public void UpdateFood(Food food)
        {
            _context.Update(food);
        }

        public void DeleteFood(Food food)
        {
            _context.Remove(food);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    
    }
}
