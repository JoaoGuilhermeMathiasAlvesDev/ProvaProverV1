using Dominio.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insfrastructure.Mapping
{
    public class AssinanteMapping : IEntityTypeConfiguration<Assinante>
    {
        public void Configure(EntityTypeBuilder<Assinante> builder)
        {
            builder.ToTable("Assinantes");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(a => a.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasIndex(a => a.Email)
                .IsUnique()
                .HasDatabaseName("IX_Assinante_Email");

            builder.Property(a => a.DataInicio)
                .IsRequired();

            builder.Property(a => a.Plano)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(a => a.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(a => a.Status)
                .IsRequired();

            builder.Ignore(a => a.TempoAssinaturaEmMeses);
        }
    }
}
