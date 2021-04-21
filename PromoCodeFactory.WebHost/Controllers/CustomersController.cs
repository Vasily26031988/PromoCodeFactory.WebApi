using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models;
using PromoCodeFactory.WebHost.Mappers;

namespace PromoCodeFactory.WebHost.Controllers
{
	/// <summary>
	/// Клиенты
	/// </summary>
	[ApiController]
	[Route("api/v1/[controller]")]
	public class CustomersController 
	    : ControllerBase
	{
		private readonly IRepository<Customer> _customerRepository;
		private readonly IRepository<Preference> _preferenceRepository;

		public CustomersController(
			IRepository<Customer> customerRepository, 
			IRepository<Preference> preferenceRepository)
		{
			_customerRepository = customerRepository;
			_preferenceRepository = preferenceRepository;
		}

		/// <summary>
		/// Получить данные всех клиентов
		/// </summary>
		[HttpGet]
		public async Task<ActionResult<List<CustomerShortResponse>>> GetCustomersAsync()
		{
			var customers = await _customerRepository.GetAllAsync();

			var response = customers
				.Select(x => new CustomerShortResponse(x)).ToList();

			return Ok(response);
		}

		/// <summary>
		/// Получить данные клиента
		/// </summary>
		/// <param name="id">Идентификатор клиента</param>
		[HttpGet("{id}")]
		public async Task<ActionResult<CustomerResponse>> GetCustomerAsync(Guid id)
		{
			var customer = await _customerRepository.GetByIdAsync(id);
			if (customer == null)
				return NotFound();

			var response = new CustomerResponse(customer);
			return Ok(response);
		}

		/// <summary>
		/// Добавить клиента
		/// </summary>
		/// <param name="request">Информация о клиенте</param>
		[HttpPost]
		public async Task<ActionResult<CustomerResponse>> CreateCustomerAsync(CreateOrEditCustomerRequest request)
		{
			if (request == null)
				return BadRequest();

			var preferences = await GetPreferencesAsync(request.PreferenceIds);
			var customer = CustomerMapper.MapFromModel(request, preferences);

			await _customerRepository.CreateAsync(customer);

			var response = new CustomerResponse(customer);
			return CreatedAtRoute(null, response);
		}

		/// <summary>
		/// Обновить данные клиента
		/// </summary>
		/// <param name="id">Идентификатор клиента</param>
		/// <param name="request">Информация о клиенте</param>
		[HttpPut("{id}")]
		public async Task<IActionResult> EditCustomerAsync(Guid id, CreateOrEditCustomerRequest request)
		{
			if (request == null)
				return BadRequest();

			var customer = await _customerRepository.GetByIdAsync(id);
			if (customer == null)
				return NotFound();

			var preferences = await GetPreferencesAsync(request.PreferenceIds);
			CustomerMapper.MapFromModel(request, preferences, customer);

			await _customerRepository.UpdateAsync(customer);

			return NoContent();
		}

		/// <summary>
		/// Удалить клиента
		/// </summary>
		/// <param name="id">Идентификатор клиента</param>
		[HttpDelete]
		public async Task<IActionResult> DeleteCustomer(Guid id)
		{
			var customer = await _customerRepository.GetByIdAsync(id);
			if (customer == null)
				return NotFound();

			await _customerRepository.DeleteAsync(customer);

			return NoContent();
		}

		public Task<IEnumerable<Preference>> GetPreferencesAsync(IEnumerable<Guid> ids)
		{
			if (ids?.Any() == true)
			{
				return _preferenceRepository
					.GetRangeByIdsAsync(ids.ToList());
			}

			return Task.FromResult(Enumerable.Empty<Preference>());
		}


	}
}
