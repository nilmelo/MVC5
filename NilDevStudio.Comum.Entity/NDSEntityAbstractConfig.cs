using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NilDevStudio.Comum.Entity
{
    public abstract class NDSEntityAbstractConfig<TEntidade> : EntityTypeConfiguration<TEntidade> where TEntidade : class
    {
        public NDSEntityAbstractConfig() // Template Method
        {
            ConfigurarNomeTabela();
            ConfigurarCamposTabela();
            ConfigurarChavePrimaria();
            ConfigurarChaveEstrangeira();
        }

        protected abstract void ConfigurarChavePrimaria();

        protected abstract void ConfigurarChaveEstrangeira();

        protected abstract void ConfigurarCamposTabela();

        protected abstract void ConfigurarNomeTabela();
    }
}
