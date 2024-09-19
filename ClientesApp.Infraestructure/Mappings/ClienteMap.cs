﻿using ClientesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Infra.Data.SqlServer.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TB_CLIENTE");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");            
            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(150)").IsRequired();         
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(150)").IsRequired();       
            builder.Property(x => x.Cpf).HasColumnName("cpf").HasColumnType("varchar(150)").IsRequired();
            
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Cpf).IsUnique();


        }
    }
}
