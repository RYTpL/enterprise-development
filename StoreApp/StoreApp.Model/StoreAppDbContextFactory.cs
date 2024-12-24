using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using StoreApp.Model;

namespace StoreApp.Model
{
    public class StoreAppDbContextFactory : IDesignTimeDbContextFactory<StoreAppContext>
    {
        public StoreAppContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreAppContext>();

            // Устанавливаем MySQL с заданной версией
            optionsBuilder.UseMySql(
                "Server=localhost;Database=storeapp1;User=root;Password=43i8jy2pvts;",
                new MySqlServerVersion(new Version(8, 0, 40)) 
            );

            return new StoreAppContext(optionsBuilder.Options);
        }
    }
}
