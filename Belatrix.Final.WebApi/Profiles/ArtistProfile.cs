using ViewModel = Belatrix.Final.WebApi.ViewModels;
using AutoMapper;
using Belatrix.Final.WebApi.Models;

namespace Belatrix.Final.WebApi.Profiles
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            CreateMap<Artist, ViewModel.Artist>()
                .ForMember(dest => dest.Key, o => o.MapFrom(src => $"{(!string.IsNullOrEmpty(src.Name) ? src.Name : "artist")}_{src.Id.ToString()}"));
        }
    }
}
