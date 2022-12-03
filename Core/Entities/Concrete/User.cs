using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string? First_name { get; set; }

        public string? Last_name { get; set; }

		public string? Email { get; set; }

        public byte[]? PasswordSalt { get; set; }

        public byte[]? PasswordHash { get; set; }

        public bool Status { get; set; }
    }
}