using NilDevStudio.Musicas.AcessoDados.Entity.Context;
using NilDevStudio.Musicas.Dominio;
using NilDevStudio.Repositorios.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NilDevStudio.Musicas.Repositorios.Entity
{
    public class AlbumRepositorio : RepositorioGenericoEntity<Album, int>
    {
        public AlbumRepositorio(MusicasDbContext contexto) : base(contexto)
        {
            
        }
    }
}
