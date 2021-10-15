using System;
using Api.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Teste
{
    public abstract class BaseTeste
    {
        public BaseTeste()
        {

        }
    }

    public class DbTeste : IDisposable
    {
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", "")}";
        public ServiceProvider ServiceProvider { get; set; }

        public DbTeste()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<DataContext>(o =>
                o.UseMySql($"Persist Security Info=True;Server=localhost;Database={dataBaseName};User=root;Password=1234"),
                ServiceLifetime.Transient
            );

            ServiceProvider = serviceCollection.BuildServiceProvider();

            using (var context = ServiceProvider.GetService<DataContext>())
            {
                context.Database.EnsureCreated();
            }

        }

        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<DataContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}

