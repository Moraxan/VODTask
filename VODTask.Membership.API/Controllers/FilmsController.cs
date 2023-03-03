using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VODTask.Membership.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FilmsController : ControllerBase
	{
		private readonly IDbService _db;

		public FilmsController(IDbService db)
		{
			_db = db;
		}

		// GET: api/<FilmsController>
		[HttpGet]
		public async Task<IResult> Get()
		{
			try
			{
				var films = await _db.GetAsync<Film, FilmDTO>();
				return Results.Ok(films);
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
				var film = await _db.SingleAsync<Film, FilmDTO>(f => f.Id == id);
				return Results.Ok(film);
			}
			catch (Exception ex)
			{
				return Results.NotFound(ex.Message);

			}
		}

		// POST api/<FilmsController>
		[HttpPost]
		public async Task<IResult> Post([FromBody] FilmCreateDTO dto) //might use FilmCreateDTO
		{
			try
			{
				var film = await _db.AddAsync<Film, FilmCreateDTO>(dto);
				var result = await _db.SaveChangesAsync();
				if (!result) return Results.BadRequest();

				return Results.Created(_db.GetURI<Film>(film), film);
			}
			catch (Exception ex)
			{
				return Results.BadRequest(ex.Message);

			}
		}

		// PUT api/<FilmsController>/5
		[HttpPut("{id}")]
		public async Task<IResult> Put(int id, [FromBody] FilmEditDTO dto)
		{
			try
			{
				if (id != dto.Id) return Results.BadRequest("Id mismatch.");
				var exists = await _db.AnyAsync<Director>(f => f.Id== dto.DirectorId);
				if (!exists) return Results.BadRequest("Director not found.");

				exists = await _db.AnyAsync<Film>(f => f.Id == id);
				if (!exists) return Results.BadRequest("Film not found.");

				_db.Update<Film, FilmEditDTO>(id,dto);
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
				
				var exists = await _db.AnyAsync<Film>(f => f.Id == id);
				if (!exists) return Results.BadRequest("Film not found.");

				

				var success= await _db.DeleteAsync<Film>(id);
				if (!success) return Results.BadRequest("Film not found.");
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
