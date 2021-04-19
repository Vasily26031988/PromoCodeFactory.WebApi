using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Models
{
    public class CustomerShortResponse
    {
	    public Guid Id { get; set; }
	    public string FirstName { get; set; }
	    public string LastName { get; set; }
	    public string Email { get; set; }

	    public CustomerShortResponse()
	    {
	    }

	    public CustomerShortResponse(Customer customer)
	    {
		    if (customer == null)
			    throw new ArgumentNullException(nameof(customer));

		    Id = customer.Id;
		    FirstName = customer.FirstName;
		    LastName = customer.LastName;
		    Email = customer.Email;
	    }
    }
}
