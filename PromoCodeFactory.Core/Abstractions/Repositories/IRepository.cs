﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Domain;

namespace PromoCodeFactory.Core.Abstractions.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
	    Task<IEnumerable<T>> GetAllAsync();

	    Task<T> GetByIdAsync(Guid id);

	    Task<IEnumerable<T>> GetRangeByIdsAsync(List<Guid> ids);

	    Task<T> GetFirstWhere(Expression<Func<T, bool>> predicate);

	    Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

	    Task CreateAsync(T entity);

	    Task UpdateAsync(T entity);

	    Task DeleteAsync(T entity);

	    Task DeleteByIdAsync(Guid id);
    }
}
