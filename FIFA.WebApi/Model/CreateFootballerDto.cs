using AutoMapper;
using FIFA.Application.Common.Mappings;
using FIFA.Application.Footballers.Commands.CreateFootballer;
using System.ComponentModel.DataAnnotations;

namespace FIFA.WebApi.Model
{
    public class CreateFootballerDto: IMapWith<CreateFootballerCommand>
    {
        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? OVR { get; set; }
        public string? POS { get; set; }
        public string? BIN { get; set; }
        public string? PAC { get; set; }
        public string? SHO { get; set; }
        public string? PAS { get; set; }
        public string? DRI { get; set; }
        public string? DEF { get; set; }
        public string? PHY { get; set; }
        public string? SM { get; set; }
        public string? WF { get; set; }
        public string? WRs { get; set; }
        public string? Foot { get; set; }
        public string? Stats { get; set; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<CreateFootballerDto, CreateFootballerCommand>()
                .ForMember(footballerCommand => footballerCommand.FirstName,
                    opt => opt.MapFrom(footballerDto => footballerDto.FirstName))
                .ForMember(footballerCommand => footballerCommand.LastName,
                    opt => opt.MapFrom(footballerDto => footballerDto.LastName))
                .ForMember(footballerCommand => footballerCommand.OVR,
                    opt => opt.MapFrom(footballerDto => footballerDto.OVR))
                .ForMember(footballerCommand => footballerCommand.POS,
                    opt => opt.MapFrom(footballerDto => footballerDto.POS))
                .ForMember(footballerCommand => footballerCommand.BIN,
                    opt => opt.MapFrom(footballerDto => footballerDto.BIN))
                .ForMember(footballerCommand => footballerCommand.PAC,
                    opt => opt.MapFrom(footballerDto => footballerDto.PAC))
                .ForMember(footballerCommand => footballerCommand.SHO,
                    opt => opt.MapFrom(footballerDto => footballerDto.SHO))
                .ForMember(footballerCommand => footballerCommand.PAS,
                    opt => opt.MapFrom(footballerDto => footballerDto.PAS))
                .ForMember(footballerCommand => footballerCommand.DRI,
                    opt => opt.MapFrom(footballerDto => footballerDto.DRI))
                .ForMember(footballerCommand => footballerCommand.DEF,
                    opt => opt.MapFrom(footballerDto => footballerDto.DEF))
                .ForMember(footballerCommand => footballerCommand.PHY,
                    opt => opt.MapFrom(footballerDto => footballerDto.PHY))
                .ForMember(footballerCommand => footballerCommand.SM,
                    opt => opt.MapFrom(footballerDto => footballerDto.SM))
                .ForMember(footballerCommand => footballerCommand.WF,
                    opt => opt.MapFrom(footballerDto => footballerDto.WF))
                .ForMember(footballerCommand => footballerCommand.WRs,
                    opt => opt.MapFrom(footballerDto => footballerDto.WRs))
                .ForMember(footballerCommand => footballerCommand.Foot,
                    opt => opt.MapFrom(footballerDto => footballerDto.Foot))
                .ForMember(footballerCommand => footballerCommand.Stats,
                    opt => opt.MapFrom(footballerDto => footballerDto.Stats));
        }
    }
}
