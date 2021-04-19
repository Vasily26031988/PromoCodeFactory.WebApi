using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodeFactory.DataAccess.Data
{
	public class EfDbInitializer : IDbInitializer
	{
		private readonly DataContext _dataContext;
		public EfDbInitializer(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public void InitializeDb()
		{
			_dataContext.Database.EnsureDeletedAsync();
			_dataContext.Database.EnsureCreatedAsync();

			_dataContext.AddRange(FakeDataFactory.Employees);
			_dataContext.SaveChangesAsync();

			_dataContext.AddRange(FakeDataFactory.Preferences);
			_dataContext.SaveChangesAsync();

			_dataContext.AddRange(FakeDataFactory.Customers);
			_dataContext.SaveChangesAsync();
		}
	}
}
