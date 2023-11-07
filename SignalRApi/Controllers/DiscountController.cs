using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiscountController : ControllerBase
	{
		private readonly IDiscountService _discountService;
		private readonly IMapper _mapper;

		public DiscountController(IDiscountService discountService, IMapper mapper)
		{
			_discountService = discountService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult DiscountList()
		{
			var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
			return Ok(value);
		}
		[HttpPost]
		public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
		{
			_discountService.TAdd(new Discount()
			{
				Amount= createDiscountDto.Amount,
				Title= createDiscountDto.Title,
				ImageUrl= createDiscountDto.ImageUrl,
				Description= createDiscountDto.Description,

			});
			return Ok("İndirim Blgisi Eklendi");
		}
		[HttpDelete]
		public IActionResult DeleteDiscount(int id)
		{
			//önce İD yi Getir ardından idye göre sil
			var value = _discountService.TGetById(id);
			_discountService.TDelete(value);
			return Ok("İndirim Alanı Silindi");
		}
		[HttpGet("GetDiscount")]
		public IActionResult GetDiscount(int id)
		{
			var value = _discountService.TGetById(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
		{
			_discountService.TUpdate(new Discount()
			{
				Amount=updateDiscountDto.Amount,
				Description=updateDiscountDto.Description,
				ImageUrl=updateDiscountDto.ImageUrl,
				Title=updateDiscountDto.Title,
				DiscountID = updateDiscountDto.DiscountID

			});
			return Ok("İndirim Bilgisi Güncellendi");
		}
	}
}