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

	var app = builder.Build();

	// Configure the HTTP request pipeline.
	
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
		options.RoutePrefix = string.Empty;
	});






app.UseHttpsRedirection();

	app.UseCors("CorsAllAccessPolicy");

	app.UseAuthorization();

	app.MapControllers();

	app.Run();


