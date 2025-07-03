using MyCSharpProject.Repository;
using MyCSharpProject.Service;

namespace MyCSharpProject.Helper;

public static class DependencyInjectionHelper
{
    public static void AddServiceFromDJHelper(this IServiceCollection service)
    {
        // add service here
        service.AddScoped<IUserRepository, UserRepository>();
        service.AddScoped<IUserService, UserService>();
    }
}

