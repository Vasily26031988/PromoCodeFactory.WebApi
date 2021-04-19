using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;


namespace PromoCodeFactory.DataAccess.Repositories
{
	public class EfRepository<T>
		: IRepository<T>
		where T : BaseEntity
	{
		private readonly DataContext _dataContext;


		public EfRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task CreateAsync(T entity)
		{
			if (entity == null)
				throw new ArgumentNullException(nameof(entity));

			await _dataContext.Set<T>().AddAsync(entity);
			await _dataContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			if (entity == null)
				throw new ArgumentNullException(nameof(entity));

			_dataContext.Set<T>().Remove(entity);
			await _dataContext.SaveChangesAsync();
		}

		public async Task DeleteByIdAsync(Guid id)
		{
			var entity = await _dataContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
			if (entity == null)
				throw new ArgumentException(
					"An entry with this identifier does not exist.", nameof(id));
			await _dataContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			var entity = await _dataContext.Set<T>().ToListAsync();
			return entity;
		}

		public async Task<T> GetByIdAsync(Guid id)
		{
			var entity = await _dataContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
			return entity;
		}

		public async Task<T> GetFirstWhere(Expression<Func<T, bool>> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));
			
			var entities = await _dataContext.Set<T>().FirstOrDefaultAsync(predicate);
			return entities;
		}

		public async Task<IEnumerable<T>> GetRangeByIdsAsync(List<Guid> ids)
		{
			if (ids == null)
				throw new ArgumentNullException(nameof(ids));

			var entities = await _dataContext.Set<T>().Where(x => ids.Contains(x.Id)).ToListAsync();
			return entities;
		}

		public Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(T entity)
		{
			throw new NotImplementedException();
		}
	}
}
