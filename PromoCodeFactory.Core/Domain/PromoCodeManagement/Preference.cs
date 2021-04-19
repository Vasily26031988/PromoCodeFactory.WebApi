﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
	public class Preference : BaseEntity
	{
		[MaxLength(100)]
		public string Name { get; set; }
	}
}
