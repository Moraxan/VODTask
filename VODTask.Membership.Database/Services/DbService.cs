namespace VODTask.Membership.Database.Services
{
	public class DbService : IDbService
	{
		private readonly VODContext _db;
		private readonly IMapper _mapper;



		public DbService(VODContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}

		public async Task<TDto> GetSingleAsync<TEntity, TDto>(int id) where TEntity : class where TDto : class
		{
			try
			{
				var entity = await _db.Set<TEntity>().FindAsync(id);
				return _mapper.Map<TDto>(entity);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<List<TDto>> GetAllAsync<TEntity, TDto>() where TEntity : class where TDto : class
		{
			try
			{
				var entities = await _db.Set<TEntity>().ToListAsync();
				return _mapper.Map<List<TDto>>(entities);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<int> CreateAsync<TEntity, TDto>(TDto item) where TEntity : class where TDto : class
		{
			try
			{
				var entity = _mapper.Map<TEntity>(item);
				_db.Set<TEntity>().Add(entity);
				await _db.SaveChangesAsync();
				return entity.Id;
			}
			catch (Exception ex)
			{
				// Handle the exception
				return -1;
			}
		}

		public async Task<bool> UpdateAsync<TEntity, TDto>(TDto item) where TEntity : class where TDto : class
		{
			try
			{
				var entity = await _db.Set<TEntity>().FindAsync(item.GetType().GetProperty("Id")?.GetValue(item));
				if (entity == null) return false;
				_mapper.Map(item, entity);
				_db.Set<TEntity>().Update(entity);
				return await _db.SaveChangesAsync() > 0;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<bool> DeleteAsync<TEntity>(int id) where TEntity : class
		{
			try
			{
				var entity = await _db.Set<TEntity>().FindAsync(id);
				if (entity == null) return false;
				_db.Set<TEntity>().Remove(entity);
				return await _db.SaveChangesAsync() > 0;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}

