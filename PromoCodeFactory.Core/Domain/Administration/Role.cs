using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PromoCodeFactory.Core.Domain.Administration
{
    public class Role  : BaseEntity
    {
	    [MaxLength(100)]
	    public string Name  { get; set; }

	    [MaxLength(100)]
		public string Description { get; set; }
    }
}
