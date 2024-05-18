using Gifts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phon { get; set; }
        public string Mail { get; set; }
        public int Status { get; set; }
        public DateTime DateOfStatusChange { get; set; }
        public string Password { get; set; }
        public ICollection<Gift> GiftsList { get; set; }

    }
}
