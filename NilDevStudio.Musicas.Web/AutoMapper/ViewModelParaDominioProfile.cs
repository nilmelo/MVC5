using AutoMapper;
using NilDevStudio.Musicas.Dominio;
using NilDevStudio.Musicas.Web.ViewModels.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NilDevStudio.Musicas.Web.AutoMapper
{
    public class ViewModelParaDominioProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<AlbumIndexViewModel, Album>();
        }
    }
}