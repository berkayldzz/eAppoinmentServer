using eAppoinmentServer.Domain.Entities;
using eAppoinmentServer.Infrastructure.Context;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace eAppoinmentServer.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });

            // AddIdentity metodu, ASP.NET Core Identity sistemini uygulamaya ekler.Identity kütüphanesi kullandığımız için bir dependency inject yapıyoruz ayrıca şifre gereksinimlerini özelleştirdik.

            services.AddIdentity<AppUser, AppRole>(action =>
            {
                action.Password.RequiredLength = 1;
                action.Password.RequireUppercase = false;
                action.Password.RequireLowercase = false;
                action.Password.RequireNonAlphanumeric = false;
                action.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            // IUnitOfWork interfacei ApplicationDbContext classına bağlı.

            services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

            //services.AddScoped<IAppointmentRepository,AppointmentRepository>();
            //services.AddScoped<IDoctorRepository,DoctorRepository>();
            //services.AddScoped<IPatientRepository,PatientRepository>();
            //services.AddScoped<IJwtProvider, JwtProvider>();


            // Bu kütüphane sayesinde yukarıdaki gibi bir eşleştirme yapmama gerek kalmadı.
            // İsimleri aynı olduğu sürece otomatik bir eşleme yapar.IPatientRepository  PatientRepository gibi.

            services.Scan(action =>
            {
                action
                .FromAssemblies(typeof(DependencyInjection).Assembly)
                .AddClasses(publicOnly: false)
                .UsingRegistrationStrategy(registrationStrategy: RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime();
            });


            return services;
        }
    }
}
