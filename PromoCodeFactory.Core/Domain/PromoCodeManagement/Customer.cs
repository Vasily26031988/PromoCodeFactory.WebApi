using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class Customer : BaseEntity
    {
	    [MaxLength(100)]
		public string FirstName { get; set; }

		[MaxLength(100)]
		public string LastName { get; set; }

	    public string Fullname => $"{FirstName}{LastName}";

	    [MaxLength(100)]
	    public string Email { get; set; }

	    public virtual ICollection<CustomerPreference> Preferences { get; set; }

		public virtual ICollection<PromoCodeCustomer> PromoCodes { get; set; }
    }
}
