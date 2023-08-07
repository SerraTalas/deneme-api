using AutoMapper;
using DenemeAPI.Data;
using DenemeAPI.Dto;
using DenemeAPI.GenericRepository;
using DenemeAPI.Models;
using DenemeAPI.Request;
using DenemeAPI.Response;
using DenemeAPI.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DenemeAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class BookController : Controller
	{
		private readonly IBookService _bookService;
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;
		private readonly DataContext _context;

		public BookController(IBookService bookService, ICategoryService categoryService, IMapper mapper, DataContext context)
        {
			_bookService = bookService;
			_categoryService = categoryService;
			_mapper = mapper;
			_context = context;
		}
		//deneme

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(List<Book>))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetBooks()
		{
			var books = await _bookService.GetAllAsync();
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var response = _mapper.Map<List<GetBookResponse>>(books);
			return Ok(response);
		}

		[HttpGet("{bookId}")]
		[ProducesResponseType(200, Type = typeof(Book))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetBookById(int bookId)
		{
			var book = await _bookService.GetByIdAsync(bookId);
            if (book == null)
				return NotFound();

            if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var response = _mapper.Map<GetBookResponse>(book);
			return Ok(response);
		}

		[HttpPost]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> AddBook([FromBody]AddBookRequest request) 
		{
			if(request == null)
				return BadRequest(ModelState);

			var books = await _bookService.GetAllAsync();

			if(books.Any(b => b.Name == request.Name))
			{
				ModelState.AddModelError("", "Book already exists");
				return StatusCode(422, ModelState);
			}

			if(!ModelState.IsValid)
				return BadRequest(ModelState);

			var bookDto = _mapper.Map<BookDto>(request);
			
			if(bookDto == null)
				return BadRequest(ModelState);

			var result = await _bookService.AddAsync(bookDto);

			var bookResponse = _mapper.Map<AddBookResponse>(result);

			return Ok(bookResponse);
		}

		[HttpPut]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> UpdateBook([FromBody]UpdateBookRequest request)
		{
			if (request == null)
				return BadRequest(ModelState);

			if(!_bookService.Exists(request.Id))
				return NotFound();

			if (!ModelState.IsValid) 
				return BadRequest(ModelState);

			var bookDto = _mapper.Map<BookDto>(request);

			await _bookService.UpdateAsync(bookDto);

			var bookResponse = _mapper.Map<UpdateBookRequest>(bookDto);

			return Ok(bookResponse);
		}

		[HttpDelete("{bookId}")]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> DeleteBook(int bookId)
		{
			if (!_bookService.Exists(bookId))
				return NotFound();

			if(!ModelState.IsValid)
				return BadRequest(ModelState);

			await _bookService.DeleteAsync(bookId);

			return Ok("Successfully deleted.");
		}
	}
}
