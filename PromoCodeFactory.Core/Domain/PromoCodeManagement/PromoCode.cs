using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using PromoCodeFactory.Core.Domain.Administration;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class PromoCode : BaseEntity
    {
	    [MaxLength(100)]
		public string Code { get; set; }

		[MaxLength(100)]
		public string ServiceInfo { get; set; }

	    public DateTime BeginDate { get; set; }

	    public DateTime EndDate { get; set; }

	    [MaxLength(100)]
	    public string PartnerName { get; set; }

	    public Guid? PartnerManagerId { get; set; }

		public virtual Employee PartnerManager { get; set; }

	    public Guid PreferenceId { get; set; }

		public virtual Preference Preference { get; set; }

		public virtual ICollection<PromoCodeCustomer> Customers { get; set; }
    }
}
