using Microsoft.OpenApi.Models;

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


ConfigureAutomapper(builder.Services);
ConfigureServices(builder.Services);


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


//Configuring Automapper
void ConfigureAutomapper(IServiceCollection services)
{ 
	var config = new AutoMapper.MapperConfiguration(cfg =>
	{
		cfg.CreateMap<Film, FilmDTO>()
		.ForMember(dest => dest.SimilarFilms, opt => opt.MapFrom(src => src.SimilarFilms.ToList()))
		//.ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director))
		//.ForMember(dest => dest.SimilarFilms, opt => opt.MapFrom(src => src.SimilarFilms))
		//.ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres))
		.ReverseMap();

		cfg.CreateMap<Director, DirectorDTO>()
			.ReverseMap();

		cfg.CreateMap<FilmGenre, FilmGenreDTO>()
			.ReverseMap();

		cfg.CreateMap<Genre, GenreDTO>()
			.ReverseMap();

		cfg.CreateMap<SimilarFilm, SimilarFilmDTO>().ReverseMap();
	});
	var mapper = config.CreateMapper();
	builder.Services.AddSingleton(mapper);
}
void ConfigureServices(IServiceCollection services)
{
	services.AddScoped<IDbService, DbService>();
}