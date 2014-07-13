﻿using System;
using Microsoft.AspNet.Identity.Entity;
using Microsoft.Data.Entity;
using Microsoft.Framework.DependencyInjection;

namespace iam1414.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : User
    {

    }

    public class ApplicationDbContext : IdentitySqlContext<ApplicationUser>
    {
        private static bool _created = false;
        
        public ApplicationDbContext(IServiceProvider serviceProvider, IOptionsAccessor<DbContextOptions> optionsAccessor)
            : base(serviceProvider, optionsAccessor.Options.BuildConfiguration())
        {            
            // Create the database and schema if it doesn't exist
            // This is a temporary workaround to create database until Entity Framework database migrations 
            // are supported in ASP.NET vNext
            if (!_created)
            {
                Database.EnsureCreated();
                _created = true;
            }
        }
    }
}