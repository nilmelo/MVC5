﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NilDevStudio.Musicas.Web.ViewModels.Musica
{
    public class MusicaExibicaoViewModel
    {
        public long Id { get; set; }
        [Display(Name = "Nome da música")]
        public string Nome { get; set; }
        [Display(Name = "Nome do álbum")]
        public string NomeAlbum { get; set; }
    }
}