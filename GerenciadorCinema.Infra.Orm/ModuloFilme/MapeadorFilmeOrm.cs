using GerenciadorCimena.Dominio.ModuloFilmes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorCinema.Infra.Orm.ModuloFilme
{
    public class MapeadorFilmeOrm
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("TBFilme");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Imagem).HasColumnType("varchar(MAX)").IsRequired();
            builder.Property(x => x.Titulo).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Descricao).HasColumnType("varchar(500)").IsRequired();
            builder.Property(x => x.Duracao).HasColumnType("time").IsRequired();
            

            builder.HasOne(x => x.Usuario)
               .WithMany()
               .IsRequired(false)
               .HasForeignKey(x => x.UsuarioId)
               .OnDelete(DeleteBehavior.NoAction);
        }


    }
}
