﻿using ClientesApp.Infra.Data.SqlServer.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ClientesApp.Infra.Data.SqlServer.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
        }
    }
}
