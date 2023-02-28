using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VODTask.Membership.Database.Services
{
	public interface IDbService
	{
		Task<TDto> GetSingleAsync<TEntity, TDto>(int id) where TEntity : class where TDto : class;
		Task<List<TDto>> GetAllAsync<TEntity, TDto>() where TEntity : class where TDto : class;
		Task<int> CreateAsync<TEntity, TDto>(TDto item) where TEntity : class where TDto : class;
		Task<bool> UpdateAsync<TEntity, TDto>(TDto item) where TEntity : class where TDto : class;
		Task<bool> DeleteAsync<TEntity>(int id) where TEntity : class;
		

	}
}
