using Microsoft.EntityFrameworkCore;
using ContosoPizza.Models;


namespace ContosoPizza.Data;

public class PizzaContext : DbContext
{
   protected readonly IConfiguration Configuration;
    public PizzaContext (IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            

            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("Conection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

    public DbSet<Pizza> Pizzas => Set<Pizza>();
    public DbSet<Topping> Toppings => Set<Topping>();
    public DbSet<Sauce> Sauces => Set<Sauce>();
}



