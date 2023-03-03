using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VODTask.Membership.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenresController : ControllerBase
	{
		private readonly IDbService _db;

		public GenresController(IDbService db)
		{
			_db = db;
		}

		// GET: api/<FilmsController>
		[HttpGet]
		public async Task<IResult> Get()
		{
			try
			{
				var genres = await _db.GetAsync<Genre, GenreBaseDTO>();
				return Results.Ok(genres);
			}
			catch (Exception ex)
			{
				return Results.NotFound(ex.Message);

			}
		}
			

		// GET api/<FilmsController>/5
		[HttpGet("{id}")]
		public async Task<IResult> Get(int id)
		{
			try
			{
				var genre = await _db.SingleAsync<Genre, GenreBaseDTO>(d => d.Id == id);
				return Results.Ok(genre);
			}
			catch (Exception ex)
			{
				return Results.NotFound(ex.Message);

			}
		}

		// POST api/<FilmsController>
		[HttpPost]
		public async Task<IResult> Post([FromBody] GenreBaseDTO dto) //might use FilmCreateDTO
		{
			try
			{
				var genre = await _db.AddAsync<Genre, GenreBaseDTO>(dto);
				var result = await _db.SaveChangesAsync();
				if (!result) return Results.BadRequest();

				return Results.Created(_db.GetURI<Genre>(genre), genre);
			}
			catch (Exception ex)
			{
				return Results.BadRequest(ex.Message);

			}
		}

		// PUT api/<FilmsController>/5
		[HttpPut("{id}")]
		public async Task<IResult> Put(int id, [FromBody] GenreBaseDTO dto)
		{
			try
			{
				

				var exists = await _db.AnyAsync<Genre>(d => d.Id == id);
				if (!exists) return Results.BadRequest("Genre not found.");

				_db.Update<Genre, GenreBaseDTO>(id,dto);
				var result = await _db.SaveChangesAsync();
				if (!result) return Results.BadRequest();

				return Results.NoContent(); 
			}
			catch (Exception ex)
			{
				return Results.BadRequest(ex.Message);

			}
		}

		// DELETE api/<FilmsController>/5
		[HttpDelete("{id}")]
		public async Task<IResult> Delete(int id)
		{
			try
			{
				
				var exists = await _db.AnyAsync<Genre>(g => g.Id == id);
				if (!exists) return Results.BadRequest("Genre not found.");

				

				var success= await _db.DeleteAsync<Genre>(id);
				if (!success) return Results.BadRequest("Genre not found.");
				var result = await _db.SaveChangesAsync();
				if (!result) return Results.BadRequest();

				return Results.NoContent();
			}
			catch (Exception)
			{
				return Results.BadRequest("Could not delete the course.");

			}
		}
	}
}
