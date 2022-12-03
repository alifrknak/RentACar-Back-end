using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
	public class UserForRegisterDto :IDto
	{
		public string? First_name { get; set; }

		public string? Last_name { get; set; }

		public string? Email { get; set; }

		public string? Password { get; set; }
	}
}
