

using GerenciadorCimena.Dominio.ModuloSessoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorCinema.Infra.Orm.ModuloSessao
{
    public class MapeadorSessaoOrm : IEntityTypeConfiguration<Sessao>
    {
        public void Configure(EntityTypeBuilder<Sessao> builder)
        {
            builder.ToTable("TBSessao");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.HorarioInicio).HasColumnType("time").IsRequired();
            builder.Property(x => x.HorarioFim).HasColumnType("time").IsRequired();
            builder.Property(x => x.ValorIngresso).IsRequired();
            builder.Property(x => x.Animacao).HasConversion<int>().IsRequired();
            builder.Property(x => x.Audio).HasConversion<int>().IsRequired();

           

            builder.HasOne(x => x.Filme)
                .WithMany(x => x.Sessoes)
                .IsRequired(false)
                .HasForeignKey(x => x.FilmeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Sala)
                .WithMany(x => x.Sessoes)
                .IsRequired(false)
                .HasForeignKey(x => x.SalaId)
                .OnDelete(DeleteBehavior.NoAction);

        }

    }
}
