using AutoMapper;
using FIFA.Application.Common.Mappings;
using FIFA.Domain;

namespace FIFA.Application.Footballers.Queries.GetFootballer
{
    public class FootballerVm : IMapWith<Footballer>
    {
        public Guid Id { get; set; }
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
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Footballer, FootballerVm>()
                .ForMember(footballerVm => footballerVm.Id,
                    opt => opt.MapFrom(footballer=>footballer.Id))
                .ForMember(footballerVm => footballerVm.FirstName,
                    opt => opt.MapFrom(footballer => footballer.FirstName))
                .ForMember(footballerVm => footballerVm.LastName,
                    opt => opt.MapFrom(footballer => footballer.LastName))
                .ForMember(footballerVm => footballerVm.OVR,
                    opt => opt.MapFrom(footballer => footballer.OVR))
                .ForMember(footballerVm => footballerVm.POS,
                    opt => opt.MapFrom(footballer => footballer.POS))
                .ForMember(footballerVm => footballerVm.BIN,
                    opt => opt.MapFrom(footballer => footballer.BIN))
                .ForMember(footballerVm => footballerVm.PAC,
                    opt => opt.MapFrom(footballer => footballer.PAC))
                .ForMember(footballerVm => footballerVm.SHO,
                    opt => opt.MapFrom(footballer => footballer.SHO))
                .ForMember(footballerVm => footballerVm.PAS,
                    opt => opt.MapFrom(footballer => footballer.PAS))
                .ForMember(footballerVm => footballerVm.DRI,
                    opt => opt.MapFrom(footballer => footballer.DRI))
                .ForMember(footballerVm => footballerVm.DEF,
                    opt => opt.MapFrom(footballer => footballer.DEF))
                .ForMember(footballerVm => footballerVm.PHY,
                    opt => opt.MapFrom(footballer => footballer.PHY))
                .ForMember(footballerVm => footballerVm.SM,
                    opt => opt.MapFrom(footballer => footballer.SM))
                .ForMember(footballerVm => footballerVm.WF,
                    opt => opt.MapFrom(footballer => footballer.WF))
                .ForMember(footballerVm => footballerVm.WRs,
                    opt => opt.MapFrom(footballer => footballer.WRs))
                .ForMember(footballerVm => footballerVm.Foot,
                    opt => opt.MapFrom(footballer => footballer.Foot))
                .ForMember(footballerVm => footballerVm.Stats,
                    opt => opt.MapFrom(footballer => footballer.Stats))
                .ForMember(footballerVm => footballerVm.CreatedAt,
                    opt => opt.MapFrom(footballer => footballer.CreatedAt))
                .ForMember(footballerVm => footballerVm.EditedAt,
                    opt => opt.MapFrom(footballer => footballer.EditedAt));
        }
    }
}
