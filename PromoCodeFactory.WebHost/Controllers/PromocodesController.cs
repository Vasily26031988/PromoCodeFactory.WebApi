using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Mappers;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.Controllers
{
	/// <summary>
	/// Промокоды
	/// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
	public class PromocodesController 
	    : ControllerBase
	{
		private readonly IRepository<PromoCode> _promoCodeRepository;
		private readonly IRepository<Preference> _preferenceRepository;
		private readonly IRepository<Customer> _customerRepository;



        public PromocodesController(IRepository<PromoCode> promoCodeRepository, IRepository<Preference> preferenceRepository, IRepository<Customer> customerRepository)
        {
	        _promoCodeRepository = promoCodeRepository;
	        _preferenceRepository = preferenceRepository;
	        _customerRepository = customerRepository;
        }

        /// <summary>
        /// Получить все промокоды
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<PromoCodeResponse>>> GetPromocodesAsync()
        {
	        var promoCodes = await _promoCodeRepository.GetAllAsync();

	        var response = promoCodes.Select(x => new PromoCodeResponse(x)).ToList();

	        return Ok(response);
        }

        /// <summary>
        /// Создать промокод и выдать его клиентам с указанным предпочтением
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<PromoCodeShortResponse>> GivePromoCodesToCustomersWithPreferenceAsync(
	        GivePromoCodeRequest request)
        {
	        if (request == null)
		        return BadRequest();

            //предпочтение по имени
            var preference = await _preferenceRepository.GetFirstWhere(
	            x => x.Name == request.Preference);
            if (preference == null)
	            return BadRequest();

	        //Клиенты с указанными предпочтениями
            var customers = await _customerRepository
	            .GetWhere(c => c.Preferences.Any(x => 
		            x.Preference.Id == preference.Id));

            var promoCode = PromoCodeMapper.MapFromModel(request, preference, customers);

            await _promoCodeRepository.CreateAsync(promoCode);

            var response = new PromoCodeShortResponse(promoCode);
            return CreatedAtRoute(null, response);

        }
	}
}
