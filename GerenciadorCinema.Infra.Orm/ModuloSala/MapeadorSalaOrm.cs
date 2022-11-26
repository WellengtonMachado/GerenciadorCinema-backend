using GerenciadorCimena.Dominio.ModuloSalas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorCinema.Infra.Orm.ModuloSala
{
    public class MapeadorSalaOrm : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.ToTable("TBSala");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.QuantidadeAssentos).IsRequired();

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .IsRequired(false)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new Sala("Sala 1", 15));
            builder.HasData(new Sala("Sala 2", 20));
            builder.HasData(new Sala("Sala 3", 25));
        }


    }
}
