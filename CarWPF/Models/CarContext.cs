using CarWPF.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace CarWPF.Models;

internal class CarContext:DbContext
{
    public DbSet<Car> Cars { get; set; }

    public CarContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB;Integrated Security = SSPI; Database = Cars;");
    }
}
