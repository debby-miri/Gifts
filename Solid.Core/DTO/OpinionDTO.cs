using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.DTO
{
    public class OpinionDTO
    {
        public int OpinionId { get; set; }
        public string Description { get; set; }
        public bool PositiveOpinion { get; set; }
        public int GiftId { get; set; }
    }
}
