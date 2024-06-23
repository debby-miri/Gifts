using Gifts;
using Solid.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.DTO
{
    public class GiftDTO
    {
        public int GiftId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfViews { get; set; }
        public double StartingAge { get; set; }
        public double EndingAge { get; set; }
        public double EstimatedPrice { get; set; }
        public int GenderId { get; set; }
        public string Link { get; set; }
        public DateTime DateOfEntry { get; set; }
        public string ImageUrl { get; set; }
        public int EventsId { get; set; }
        public int CategryId { get; set; }
        public ICollection<Opinion> OpinionsList { get; set; }
        public int UserId { get; set; }
        public string EventName { get; set; }
        public string GenderName { get; set; }
        public string CategoryName { get; set; }
    }
}
