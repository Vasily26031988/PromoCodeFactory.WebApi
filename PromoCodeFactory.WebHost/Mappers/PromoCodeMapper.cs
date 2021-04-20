using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.Mappers
{
    public class PromoCodeMapper
    {
	    public static PromoCode MapFromModel(
		    GivePromoCodeRequest request,
		    Preference preference,
		    IEnumerable<Customer> customers)
	    {
		    var promoCode = new PromoCode
		    {
			    Code = request.PromoCode,
			    ServiceInfo = request.ServiceInfo,
			    PartnerName = request.PartnerName,
			    BeginDate = DateTime.Today,
			    EndDate = DateTime.Today.AddDays(30),
				Preference = preference,
				Customers = new List<PromoCodeCustomer>(),
		    };

		    if (customers?.Any() == false)
			    return promoCode;

		    promoCode.Customers = customers
			    .Select(x => new PromoCodeCustomer(promoCode, x))
			    .ToList();


			return promoCode;
		}
    }
}
