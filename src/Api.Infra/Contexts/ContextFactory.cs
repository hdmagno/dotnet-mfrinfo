using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Infra.Contexts
{
    public class ContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=1234";
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseMySql(connectionString);
            return new DataContext(optionsBuilder.Options);
        }
    }
}
