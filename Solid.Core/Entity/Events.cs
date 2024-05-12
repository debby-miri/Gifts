using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Entity
{
    public class Events1
    {
        [Key]
        public int EventsId { get; set; }
        public string Name { get; set;}
    }
}
