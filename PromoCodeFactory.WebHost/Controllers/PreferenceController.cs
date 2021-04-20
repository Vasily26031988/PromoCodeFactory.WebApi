using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.Controllers
{
	/// <summary>
	/// Предпочтения
	/// </summary>
	[ApiController]
    [Route("api/v1/[controller]")]
	public class PreferenceController 
	    : ControllerBase
	{
		private readonly IRepository<Preference> _preferenceRepository;


		public PreferenceController(IRepository<Preference> preferenceRepository)
		{
			_preferenceRepository = preferenceRepository;
		}

		/// <summary>
		/// Получить список предпочтений
		/// </summary>
		[HttpGet]
		public async Task<ActionResult<List<PreferenceResponse>>> GetPreferencesAsync()
		{
			var preferences = await _preferenceRepository.GetAllAsync();

			var response = preferences
				.Select(x=> new PreferenceResponse(x)).ToList();

			return Ok(response);
		}
	}
}
