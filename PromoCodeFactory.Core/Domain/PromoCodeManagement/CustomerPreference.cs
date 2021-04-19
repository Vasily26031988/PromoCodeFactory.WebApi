using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class CustomerPreference : BaseEntity
    {

	    public Guid CustomerId { get; set; }

	    public virtual Customer Customer { get; set; }

	    public Guid PreferenceId { get; set; }

	    public virtual Preference Preference { get; set; }
	    public CustomerPreference()
	    {
	    }

	    public CustomerPreference(Customer customer, Preference preference)
	    {
		    Customer = customer ?? throw new ArgumentNullException(nameof(customer));
		    Preference = preference ?? throw new ArgumentNullException(nameof(preference));
	    }


	}
}
