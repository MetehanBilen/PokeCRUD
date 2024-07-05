﻿using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services,IConfiguration configuration)
    {

        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("PokeDatabase")));

        services.AddScoped<IAbilityRepository, AbilityRepository>();
        services.AddScoped<IPokemonRepository, PokemonRepository>();
        services.AddScoped<IWeaknessRepository, WeaknessRepository>();

        return services; 
    }
}