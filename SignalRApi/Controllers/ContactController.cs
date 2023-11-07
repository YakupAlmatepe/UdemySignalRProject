using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;
		private readonly IMapper _mapper;

		public ContactController(IContactService contactService, IMapper mapper)
		{
			_contactService = contactService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ContactList()
		{
			var value = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
			return Ok(value);
		}
		[HttpPost]
		public IActionResult CreateContact(CreateContactDto createContactDto)
		{
			_contactService.TAdd(new Contact()
			{
				Location = createContactDto.Location,
				Mail = createContactDto.Mail,
				FooterDescription = createContactDto.FooterDescription,
				Phone = createContactDto.Phone

			});
			return Ok("İletişim Eklendi");
		}
		[HttpDelete]
		public IActionResult DeleteContact(int id)
		{
			//önce İD yi Getir ardından idye göre sil
			var value = _contactService.TGetById(id);
			_contactService.TDelete(value);
			return Ok("İletişim Alanı Silindi");
		}
		[HttpGet("GetContact")]
		public IActionResult GetContact(int id)
		{
			var value = _contactService.TGetById(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateContact(UpdateContactDto updatecontactDto)
		{
			_contactService.TUpdate(new Contact()
			{
				ContactID= updatecontactDto.ContactID,
				Phone= updatecontactDto.Phone,
				FooterDescription= updatecontactDto.FooterDescription,
				Mail= updatecontactDto.Mail,
				Location = updatecontactDto.Location
				
			});
			return Ok("İletişim Bilgisi Güncellendi");
		}
	}
}