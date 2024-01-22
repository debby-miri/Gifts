using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gifts
{
    public class Opinion
    {
        [Key]
        public int OpinionId { get; set; }
        public string Description { get; set; }
        public bool PositiveOpinion { get; set; }
        public Gift Gift { get; set; }

    }
}
