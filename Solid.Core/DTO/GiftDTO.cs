﻿using Gifts;
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
        public Gender Gender { get; set; }
        public string Link { get; set; }
        public DateTime DateOfEntry { get; set; }
        public string ImageUrl { get; set; }
        public Events1 Events { get; set; }
        public Categry Categry { get; set; }
        public ICollection<Opinion> OpinionsList { get; set; }
        public int UserId { get; set; }
    }
}
