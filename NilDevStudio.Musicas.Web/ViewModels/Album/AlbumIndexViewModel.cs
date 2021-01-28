using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NilDevStudio.Musicas.Web.ViewModels.Album
{
    public class AlbumIndexViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nome do álbum")]
        public String Nome { get; set; }
        [Display(Name = "Ano do álbum")]
        public int Ano { get; set; }
        [Display(Name = "Observações")]
        public String Observacoes { get; set; }
    }
}