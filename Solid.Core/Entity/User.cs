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
        public string FirstName { get; set; }

        public string LastName { get; set; }
      

        public string Phon { get; set; }

        public string Mail { get; set; }
        //פעיל 1
        //מושהה 0
        //חסום 2
        public int Status { get; set; }

        public DateTime DateOfStatusChange { get; set; }

        public string Password { get; set; }

        public ICollection<Gift> GiftsList { get; set; }
        
    }
}
