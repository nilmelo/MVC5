using NilDevStudio.Comum.Entity;
using NilDevStudio.Musicas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NilDevStudio.Musicas.AcessoDados.Entity.TypeConfiguration
{
    class MusicaTypeConfiguration : NDSEntityAbstractConfig<Musica>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("MUS_ID");

            Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("MUS_NOME")
                .HasMaxLength(50);

            Property(p => p.IdAlbum)
                .IsRequired()
                .HasColumnName("ALB_ID");
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigurarChaveEstrangeira()
        {
            HasRequired(p => p.Album)
                .WithMany(p => p.Musicas)
                .HasForeignKey(fk => fk.IdAlbum);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("MUS_MUSICAS");
        }
    }
}
