using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.DataAccess;
using PromoCodeFactory.DataAccess.Data;
using PromoCodeFactory.DataAccess.Repositories;

namespace PromoCodeFactory.WebHost
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
			services.AddScoped<IDbInitializer, EfDbInitializer>();
			services.AddDbContext<DataContext>(builder =>
			{
				builder.UseSqlite("Filename=PromocodeFactoryDb.sqlite");
				builder.UseLazyLoadingProxies();

			});


			services.AddOpenApiDocument(options =>
			{
				options.Title = "Promocode Factory API Doc";
				options.Version = "1.0";
			});
		}
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			else
			{
				app.UseHsts();
			}

			app.UseOpenApi();
			app.UseSwaggerUi3(x =>
			{
				x.DocExpansion = "list";
			});



			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
			
			dbInitializer.InitializeDb();
		}
	}
}
