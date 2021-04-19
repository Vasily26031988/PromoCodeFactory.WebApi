using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;

namespace PromoCodeFactory.WebHost.Models
{
    public class PromoCodeShortResponse
    {
	    public Guid Id { get; set; }

	    public string Code { get; set; }

	    public string ServiceInfo { get; set; }

	    public string BeginDate { get; set; }

	    public string EndDate { get; set; }

	    public string PartnerName { get; set; }

	    
	    public PromoCodeShortResponse()
	    {
	    }

		public PromoCodeShortResponse(PromoCode promoCode)
		{
			if (promoCode == null)
				throw new ArgumentNullException(nameof(promoCode));

			Id = promoCode.Id;
			Code = promoCode.Code;
			ServiceInfo = promoCode.ServiceInfo;
			BeginDate = promoCode.BeginDate.ToString("d");
			EndDate = promoCode.EndDate.ToString("d");
			PartnerName = promoCode.PartnerName;
		}

    }
}
