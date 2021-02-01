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
    public class MusicaRepositorio : RepositorioGenericoEntity<Musica, long>
    {
        public MusicaRepositorio(MusicasDbContext contexto) : base(contexto)
        {

        }

        public override List<Musica> Selecionar()
        {
            return _contexto.Set<Musica>().Include(p => p.Album).ToList();
        }

        public override Musica SelecionarPorId(long id)
        {
            return _contexto.Set<Musica>().Include(p => p.Album).SingleOrDefault(m => m.Id == id);
        }
    }
}
