using AutoMapper;

namespace FIFA.Application.Common.Mappings
{
    public interface IMapWith<T>
    {
        void IMapWith(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
