


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VODTask.Membership.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SeedController : ControllerBase
	{
		private readonly IDbService _db;

		public SeedController(IDbService db)
		{
			_db = db;
		}
		// POST api/<SeedController>
		[HttpPost]
		
		public async Task<IResult> Seed()
		{
			
			try
			{
				await _db.SeedFilmData();
				return Results.NoContent();
			}
			catch (Exception)
			{

				return Results.BadRequest();
			}
			
		}

		
	}
}
