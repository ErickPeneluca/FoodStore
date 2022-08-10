using FoodStore.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodStore.Data
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options) { }

        public DbSet<Food> foods { get; set; }

        // Mod in db
        

    }
}
