using CleanArch.Application.Members.Behaviors;
using CleanArch.Domain.Abstractions;
using CleanArch.Infrastructure.Context;
using CleanArch.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;
using System.Reflection;

namespace CleanArch.CrossCutting.AppDependecies;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var pgsql = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(pgsql));

        // Registrar IDbConnection como uma instância única
        services.AddSingleton<IDbConnection>(provider =>
        {
            var connection = new NpgsqlConnection(pgsql);
            connection.Open();
            return connection;
        });

        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IMemberDapperRepository, MemberDapperRepository>();

        var handlers = AppDomain.CurrentDomain.Load("CleanArch.Application");
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(handlers);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        }); 

        services.AddValidatorsFromAssembly(Assembly.Load("CleanArch.Application"));

        return services;
    }
}