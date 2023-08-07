using AutoMapper;
using DenemeAPI.Dto;
using DenemeAPI.Models;
using DenemeAPI.Request;
using DenemeAPI.Response;
using DenemeAPI.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;

namespace DenemeAPI.Controllers
{

	[Route("api/[controller]/[action]")]
	[ApiController]
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
			_categoryService = categoryService;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(List<Category>))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetCategories()
		{
			var categories = await _categoryService.GetAllAsync();
			var dto = _mapper.Map<List<CategoryDto>>(categories);

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var response = _mapper.Map<List<GetCategoryResponse>>(dto);

			return Ok(response);
		}

		[HttpGet("{categoryId}")]
		[ProducesResponseType(200, Type = typeof(Category))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetCategoryById(int categoryId)
		{
			var category = await _categoryService.GetByIdAsync(categoryId);
		    var dto = _mapper.Map<CategoryDto>(category);
			if (dto == null)
				return NotFound();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var response = _mapper.Map<GetCategoryResponse>(dto);

			return Ok(response);
		}

		[HttpPost]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequest request)
		{
			if (request == null)
				return BadRequest(ModelState);

			var categories = await _categoryService.GetAllAsync();

			if (categories.Any(b => b.Name == request.Name))
			{
				ModelState.AddModelError("", "Category already exists");
				return StatusCode(422, ModelState);
			}

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var categoryDto = _mapper.Map<CategoryDto>(request);

			if (categoryDto == null)
				return BadRequest(ModelState);

			await _categoryService.AddAsync(categoryDto);

			var response = _mapper.Map<AddCategoryResponse>(categoryDto);

			return Ok(response);
		}

		[HttpPut]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest request)
		{
			if (request == null)
				return BadRequest(ModelState);

			if (!_categoryService.Exists(request.Id))
				return NotFound();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var categoryDto = _mapper.Map<CategoryDto>(request);

			await _categoryService.UpdateAsync(categoryDto);

			var response = _mapper.Map<UpdateCategoryResponse>(categoryDto);

			return Ok(response);
		}

		[HttpDelete("{categoryId}")]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> DeleteCategory(int categoryId)
		{
			if (!_categoryService.Exists(categoryId))
				return NotFound();

			if(!ModelState.IsValid)
				return BadRequest(ModelState);

			await _categoryService.DeleteAsync(categoryId);

			return Ok("Successfully deleted.");
		}

	}
}
