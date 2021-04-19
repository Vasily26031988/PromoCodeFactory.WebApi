using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class PromoCodeCustomer : BaseEntity
    {

	    public Guid PromoCodeId { get; set; }

	    public PromoCode PromoCode { get; set; }

	    public Guid CustomerId { get; set; }

	    public virtual Customer Customer { get; set; }
	    public PromoCodeCustomer()
	    {
	    }

	    public PromoCodeCustomer(PromoCode promoCode, Customer customer)
	    {
		    PromoCode = promoCode ?? throw new ArgumentNullException(nameof(promoCode));
		    Customer = customer ?? throw new ArgumentNullException(nameof(customer));
	    }

    }
}
