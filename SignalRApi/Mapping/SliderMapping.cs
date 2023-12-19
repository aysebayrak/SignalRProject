using AutoMapper;
using DtoLayer.SliderDto;
using EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class SliderMapping  :Profile
    {
        public SliderMapping()
        {
            CreateMap<Slider, ResultSliderDto>().ReverseMap();
        }
    }
}
