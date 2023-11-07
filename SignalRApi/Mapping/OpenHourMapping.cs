using AutoMapper;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.OpenHourDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class OpenHourMapping :Profile
	{
        public OpenHourMapping()
        {
			CreateMap<OpenHour, ResultOpenHourDto>().ReverseMap();
			CreateMap<OpenHour, CreateOpenHourDto>().ReverseMap();
			CreateMap<OpenHour, GetOpenHourDto>().ReverseMap();
			CreateMap<OpenHour, UpdateOpenHourDto>().ReverseMap();
		}
	}
}
