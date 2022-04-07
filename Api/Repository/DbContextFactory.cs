using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Repository
{
    public class DbContextFactory : IDesignTimeDbContextFactory<FilmeRepository>
    {
        FilmeRepository IDesignTimeDbContextFactory<FilmeRepository>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FilmeRepository>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-2TF14VB\\;Database=Filme;Trusted_Connection=True;MultipleActiveResultSets=true;");

            return new FilmeRepository(optionsBuilder.Options);
        }
    }
}
