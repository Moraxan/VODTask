using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VODTask.Membership.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DirectorsController : ControllerBase
	{
		private readonly IDbService _db;

		public DirectorsController(IDbService db)
		{
			_db = db;
		}

		// GET: api/<FilmsController>
		[HttpGet]
		public async Task<IResult> Get()
		{
			try
			{
				var films = await _db.GetAsync<Director, DirectorDTO>();
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
				var film = await _db.SingleAsync<Director, DirectorDTO>(d => d.Id == id);
				return Results.Ok(film);
			}
			catch (Exception ex)
			{
				return Results.NotFound(ex.Message);

			}
		}

		// POST api/<FilmsController>
		[HttpPost]
		public async Task<IResult> Post([FromBody] DirectorDTO dto) //might use FilmCreateDTO
		{
			try
			{
				var director = await _db.AddAsync<Director, DirectorDTO>(dto);
				var result = await _db.SaveChangesAsync();
				if (!result) return Results.BadRequest();

				return Results.Created(_db.GetURI<Director>(director), director);
			}
			catch (Exception ex)
			{
				return Results.BadRequest(ex.Message);

			}
		}

		// PUT api/<FilmsController>/5
		[HttpPut("{id}")]
		public async Task<IResult> Put(int id, [FromBody] DirectorDTO dto)
		{
			try
			{
				

				var exists = await _db.AnyAsync<Director>(d => d.Id == id);
				if (!exists) return Results.BadRequest("Director not found.");

				_db.Update<Director, DirectorDTO>(id,dto);
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
				
				var exists = await _db.AnyAsync<Director>(f => f.Id == id);
				if (!exists) return Results.BadRequest("Film not found.");

				

				var success= await _db.DeleteAsync<Director>(id);
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
