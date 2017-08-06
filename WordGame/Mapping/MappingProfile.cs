using AutoMapper;
using WordGame.Controllers.Resources;
using WordGame.Models;

namespace WordGame.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<GameResult, GameResultResource>();
            CreateMap<User, UserResource>();
            // API Resource to Domain
            //CreateMap<GameResultResource, GameResult>();

        }
	}
}