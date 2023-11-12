using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.OpenHourDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OpenHourController : ControllerBase
	{
		private readonly IOpenHourService _openHourService;
		private readonly IMapper _mapper;

		public OpenHourController(IOpenHourService openHourService, IMapper mapper)
		{
			_openHourService = openHourService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult OpenHourList()
		{
			var value = _mapper.Map<List<ResultOpenHourDto>>(_openHourService.TGetListAll());
			return Ok(value);
		}
		[HttpPost]
		public IActionResult CreateOpenHour(CreateOpenHourDto createOpenHourDto)
		{
			_openHourService.TAdd(new OpenHour()
			{
				Description=createOpenHourDto.Description,
				

			});
			return Ok("Saat  Eklendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteOpenHour(int id)
		{
			//önce İD yi Getir ardından idye göre sil
			var value = _openHourService.TGetById(id);
			_openHourService.TDelete(value);
			return Ok("Saat Silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetOpenHour(int id)
		{
			var value = _openHourService.TGetById(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateOpenHour(UpdateOpenHourDto updateOpenHourDto)
		{
			_openHourService.TUpdate(new OpenHour()
			{

				OpenHoursID = updateOpenHourDto.OpenHoursID,
				Description=updateOpenHourDto.Description

			});
			return Ok("Saat Bilgisi Güncellendi");
		}
	}
}