using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;

namespace PromoCodeFactory.WebHost.Models
{
    public class CustomerResponse
    {
	    public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
		public string Email { get; set; }

        public List<PreferenceResponse> Preferences { get; set; }
        public List<PromoCodeShortResponse> PromoCodes { get; set; }


	    public CustomerResponse()
	    {
	    }

	    public CustomerResponse(Customer customer)
	    {
		    if (customer == null)
			    throw new ArgumentNullException(nameof(customer));

		    Id = customer.Id;
		    FirstName = customer.FirstName;
		    LastName = customer.LastName;
		    Email = customer.Email;
		    Preferences = customer.Preferences?
			    .Where(x => x.Preference != null)
			    .Select(x => new PreferenceResponse(x.Preference))
			    .ToList();
		    PromoCodes = customer.PromoCodes?
			    .Select(x => new PromoCodeShortResponse(x.PromoCode))
			    .ToList();
        }
    }
}
