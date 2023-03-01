using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Collections.Specialized.BitVector32;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(policy => {
	policy.AddPolicy("CorsAllAccessPolicy", opt =>
	opt.AllowAnyOrigin()
	.AllowAnyHeader()
	.AllowAnyMethod()
	);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VODContext>(
options => options.UseSqlServer(
 builder.Configuration.GetConnectionString("VODConnection")));

void ConfigureAutoMapper()
{
	var config = new AutoMapper.MapperConfiguration(cfg =>
	{
		cfg.CreateMap<Film, FilmDTO>()
		.ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director))
		.ForMember(dest => dest.SimilarFilms, opt => opt.MapFrom(src => src.SimilarFilms))
		.ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres))
		.ReverseMap();

		cfg.CreateMap<Director, DirectorDTO>()
			.ReverseMap();

		cfg.CreateMap<FilmGenre, FilmGenreDTO>()
			.ReverseMap();

		cfg.CreateMap<Genre, GenreDTO>()
			.ReverseMap();

		cfg.CreateMap<SimilarFilm, SimilarFilmDTO>()
			.ReverseMap();
	});

	var mapper = config.CreateMapper();
	builder.Services.AddSingleton(mapper);

	var app = builder.Build();

	// Configure the HTTP request pipeline.
	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	app.UseHttpsRedirection();

	app.UseCors("CorsAllAccessPolicy");

	app.UseAuthorization();

	app.MapControllers();

	app.Run();
}

