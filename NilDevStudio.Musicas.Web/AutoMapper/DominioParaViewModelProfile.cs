using AutoMapper;
using NilDevStudio.Musicas.Dominio;
using NilDevStudio.Musicas.Web.ViewModels.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NilDevStudio.Musicas.Web.AutoMapper
{
    public class DominioParaViewModelProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Album, AlbumIndexViewModel>()
                .ForMember(p => p.Nome, opt => 
                {
                    opt.MapFrom(src =>
                        string.Format("{0} ({1})", src.Nome, src.Ano.ToString())
                    );
                });
            Mapper.CreateMap<Album, AlbumViewModel>();
        }
    }
}