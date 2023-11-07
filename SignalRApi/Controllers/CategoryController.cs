﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public CategoryController(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult CategoryList()
		{
			var value = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
			return Ok(value);
		}
		[HttpPost]
		public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
		{
			_categoryService.TAdd(new Category()
			{
				CatregoryName = createCategoryDto.CatregoryName,
				Status = true
			});
			return Ok("Kategori Eklendi");
		}
		[HttpDelete]
		public IActionResult DeleteCategory(int id)
		{
			//önce İD yi Getir ardından idye göre sil
			var value = _categoryService.TGetById(id);
			_categoryService.TDelete(value);
			return Ok("Kategori Silindi");
		}
		[HttpGet("GetCategory")]
		public IActionResult GetCategory(int id)
		{
			var value = _categoryService.TGetById(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			_categoryService.TUpdate(new Category()
			{
				CatregoryName = updateCategoryDto.CatregoryName,
				CatregoryID=updateCategoryDto.CatregoryID,
				Status = updateCategoryDto.Status
			});
			return Ok("Kategori Güncellendi");
		}
	}
}