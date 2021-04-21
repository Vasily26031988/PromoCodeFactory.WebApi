using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;

namespace PromoCodeFactory.DataAccess
{
	public class DataContext : DbContext
	{

		public DbSet<Employee> Employees { get; set; }

		public DbSet<Role> Roles { get; set; }

		public DbSet<Customer> Customers { get; set; }

		public DbSet<PromoCode> PromoCodes { get; set; }

		public DbSet<Preference> Preference { get; set; }

		public DataContext()
		{
		}
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CustomerPreference>()
				.HasKey(x => new { x.CustomerId, x.PreferenceId });
			modelBuilder.Entity<CustomerPreference>()
				.HasOne(x => x.Customer)
				.WithMany(x => x.Preferences)
				.HasForeignKey(x => x.CustomerId);
			modelBuilder.Entity<CustomerPreference>()
				.HasOne(x => x.Preference)
				.WithMany()
				.HasForeignKey(x => x.PreferenceId);

			modelBuilder.Entity<PromoCodeCustomer>()
				.HasKey(x => new { x.PromoCodeId, x.CustomerId });
			modelBuilder.Entity<PromoCodeCustomer>()
				.HasOne(x => x.PromoCode)
				.WithMany(x => x.Customers)
				.HasForeignKey(x => x.PromoCodeId);
			modelBuilder.Entity<PromoCodeCustomer>()
				.HasOne(x => x.Customer)
				.WithMany(x => x.PromoCodes)
				.HasForeignKey(x => x.CustomerId);
		}



	}
}
