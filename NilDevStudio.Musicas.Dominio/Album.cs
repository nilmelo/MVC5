﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NilDevStudio.Musicas.Dominio
{
    public class Album
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public int Ano { get; set; }
        public String Observacoes { get; set; }

        public virtual List<Musica> Musicas { get; set; }
    }
}
