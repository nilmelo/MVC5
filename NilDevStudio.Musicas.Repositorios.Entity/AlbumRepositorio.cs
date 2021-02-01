using NilDevStudio.Musicas.AcessoDados.Entity.Context;
using NilDevStudio.Musicas.Dominio;
using NilDevStudio.Repositorios.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace NilDevStudio.Musicas.Repositorios.Entity
{
    public class AlbumRepositorio : RepositorioGenericoEntity<Album, int>
    {
        public AlbumRepositorio(MusicasDbContext contexto) : base(contexto)
        {
            
        }

        public override List<Album> Selecionar()
        {
            return _contexto.Set<Album>().Include(p => p.Musicas).ToList();
        }

        public override Album SelecionarPorId(int id)
        {
            return _contexto.Set<Album>().Include(p => p.Musicas).SingleOrDefault(a => a.Id == id);
        }
    }
}
