using AutoMapper;
using FIFA.Application.Common.Mappings;
using FIFA.Domain;

namespace FIFA.Application.Footballers.Queries.GetFootballersList
{
    public class FootballerDto : IMapWith<Footballer>
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Footballer, FootballerDto>()
                .ForMember(footballerDto => footballerDto.Id,
                    opt => opt.MapFrom(footballer => footballer.Id))
                .ForMember(footballerDto => footballerDto.FirstName,
                    opt => opt.MapFrom(footballer => footballer.FirstName))
                .ForMember(footballerDto => footballerDto.LastName,
                    opt => opt.MapFrom(footballer => footballer.LastName));
        }
    }
}
