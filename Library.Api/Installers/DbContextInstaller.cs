using Library.Repository;
using Microsoft.EntityFrameworkCore;

namespace Library.Api.Installers
{
    public static class DbContextInstaller
    {
        public static void InstallDbConnection(this IServiceCollection services)
        {
            services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseInMemoryDatabase(nameof(LibraryDbContext));
            });
        }
    }
}
