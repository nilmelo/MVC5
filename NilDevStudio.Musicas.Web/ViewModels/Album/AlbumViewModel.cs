using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NilDevStudio.Musicas.Web.ViewModels.Album
{
    public class AlbumViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres no nome")]
        [Display(Name = "Nome do álbum")]
        public String Nome { get; set; }

        [Display(Name = "Ano do álbum")]
        [Required(ErrorMessage = "O ano é obrigatório")]
        public int Ano { get; set; }

        [Display(Name = "Observações")]
        [MaxLength(1000, ErrorMessage = "Máximo de 1000 caracteres")]
        public String Observacoes { get; set; }
    }
}