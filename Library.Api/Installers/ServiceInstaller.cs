using Library.Repository;
using Library.Services.Interfaces;
using Library.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace Library.Api.Installers
{
    public static class ServiceInstaller
    {
        public static void InstallServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
        }
    }
}
