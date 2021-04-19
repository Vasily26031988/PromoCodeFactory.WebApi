using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Models
{
    public class PreferenceResponse
    {
	    public Guid Id { get; set; }
        public string Name { get; set; }

	    public PreferenceResponse()
	    {
	    }

	    public PreferenceResponse(Preference preference)
	    {
		    if (preference == null)
			    throw new ArgumentNullException(nameof(preference));

		    Id = preference.Id;
		    Name = preference.Name;
	    }
        


    }
}
