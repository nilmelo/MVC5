using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NilDevStudio.Musicas.Web.ViewModels.Musica
{
    public class MusicaViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome da música é obrigatório")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        [Display(Name = "Nome da música")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Selecione um álbum válido")]
        [Display(Name = "Álbum")]
        public int IdAlbum { get; set; }
    }
}