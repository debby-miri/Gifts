using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gifts
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public string Phon { get; set; }
        [Required]

        public string Mail { get; set; }
        [Required]

        public int Status { get; set; }
        [Required]

        public DateTime DateOfStatusChange { get; set; }
        [Required]

        public string Password { get; set; }

        public ICollection<Gift> GiftsList { get; set; }
        
    }
}
