using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Financiera.Dominio.Entidades;
namespace Financiera.Infra.Datos.EF.Mapeos;
public class ClienteConfiguracion : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("CLIENTES");
        builder.HasKey(c => c.IdCliente);
        builder.Property(c => c.IdCliente).HasColumnName("ID_CLIENTE").HasComment("Identificador unico del cliente");
        builder.Property(c => c.NombreCliente).HasColumnName("NOM_CLIENTE").HasComment("Nombre del cliente").HasMaxLength(200).IsRequired();
    }
}