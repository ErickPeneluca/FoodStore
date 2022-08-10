using FoodStore.Models;

namespace FoodStore.Repository.Interfaces
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> FindFoods();
        Task<Food> FindFoodById(int id);
        void AddFood(Food food);
        void UpdateFood(Food food);
        void DeleteFood(Food food);
        Task<bool> SaveChangesAsync();
    }
}
