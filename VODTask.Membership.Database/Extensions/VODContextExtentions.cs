

namespace VODTask.Membership.Database.Extensions
{
	public static class VODContextExtentions
	{
		public static async Task SeedFilmData(this IDbService service)
		{
			try
			{
				#region Lorem-Ipsum
				var description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
				#endregion

				#region Add Directors
				//await service.AddAsync<Director, DirectorDTO>(new DirectorDTO
				//{
				//	Name = "Tage Danielsson"

				//});

				//await service.AddAsync<Director, DirectorDTO>(new DirectorDTO
				//{
				//	Name = "Hans Alfredsson"

				//});

				//await service.AddAsync<Director, DirectorDTO>(new DirectorDTO
				//{
				//	Name = "Per Åhlin"

				//});


				//await service.SaveChangesAsync();
				#endregion

				#region Add Films
				var director1 = await service.SingleAsync<Director, DirectorDTO>(d => d.Name.Equals("Tage Danielsson"));
				var director2 = await service.SingleAsync<Director, DirectorDTO>(d => d.Name.Equals("Hans Alfredsson"));
				var director3 = await service.SingleAsync<Director, DirectorDTO>(d => d.Name.Equals("Per Åhlin"));

				await service.AddAsync<Film, FilmDTO>(new FilmDTO
				{
					DirectorId = director1.Id,
					Title = "Släpp fångarene loss det är vår",
					Released = new DateTime(1975, 12, 6),
					Free = true,
					Description = description,
					FilmUrl = "https://www.youtube.com/watch?v=YAUMQzGP1xs"
					
				});

				await service.AddAsync<Film, FilmDTO>(new FilmDTO
				{
					DirectorId = director1.Id,
					Title = "Att angöra en brygga",
					Released = new DateTime(1965, 12, 26),
					Free = true,
					Description = description,
					FilmUrl = "https://www.youtube.com/watch?v=UVVxZXvGCw8"

				});

				await service.AddAsync<Film, FilmDTO>(new FilmDTO
				{
					DirectorId = director2.Id,
					Title = "Mosebacke Monarki",
					Released = new DateTime(1958, 10, 06),
					Free = false,
					Description = description,
					FilmUrl = "https://www.youtube.com/watch?v=Ba7CtbOs6EE"

				});
				await service.AddAsync<Film, FilmDTO>(new FilmDTO
				{
					DirectorId = director3.Id,
					Title = "I huvet på en gammal gubbe",
					Released = new DateTime(1968, 12, 06),
					Free = false,
					Description = description,
					FilmUrl = "https://www.youtube.com/watch?v=_VsDFCVBuVI"

				});

				await service.SaveChangesAsync();
				#endregion

			}
			catch (Exception ex)
			{

				throw;
			}






		}
	}
}
