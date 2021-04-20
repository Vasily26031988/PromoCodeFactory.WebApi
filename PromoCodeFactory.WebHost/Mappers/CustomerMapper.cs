using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.Mappers
{
    public class CustomerMapper
    {
	    public static Customer MapFromModel(CreateOrEditCustomerRequest request, IEnumerable<Preference> preference,
		    Customer customer = null)
	    {
		    customer ??= new Customer
		    {
			    Preferences = new List<CustomerPreference>(),
			    PromoCodes = new List<PromoCodeCustomer>(),
		    };

		    customer.FirstName = request.FirstName;
		    customer.LastName = request.LastName;
		    customer.Email = request.Email;

			customer.Preferences?.Clear();
			if (preference?.Any() == false)
				return customer;

			customer.Preferences = preference
				.Select(x => new CustomerPreference(customer, x))
				.ToList();

			return customer;
	    }
    }
}
