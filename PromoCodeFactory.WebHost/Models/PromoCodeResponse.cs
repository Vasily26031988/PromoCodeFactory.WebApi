using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;

namespace PromoCodeFactory.WebHost.Models
{
    public class PromoCodeResponse
    {
	    public Guid Id { get; set; }

	    public string Code { get; set; }

	    public string ServiceInfo { get; set; }

	    public string BeginDate { get; set; }

	    public string EndDate { get; set; }

	    public string PartnerName { get; set; }
	    
		public List<CustomerShortResponse> Customers { get; set; }
	    public PromoCodeResponse()
	    {
	    }

	    public PromoCodeResponse(PromoCode promoCode)
	    {
		    if (promoCode == null)
			    throw new ArgumentNullException(nameof(promoCode));

		    Id = promoCode.Id;
		    Code = promoCode.Code;
		    ServiceInfo = promoCode.ServiceInfo;
		    BeginDate = promoCode.BeginDate.ToString("d");
		    EndDate = promoCode.EndDate.ToString("d");
		    PartnerName = promoCode.PartnerName;
		    Customers = promoCode.Customers?
			    .Select(x => new CustomerShortResponse(x.Customer))
			    .ToList();
		}


    }
}
