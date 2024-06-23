using Solid.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gifts
{
/*    public enum EEvents {EVERY,BIRTHDAY,WEDDING,BAR_MITZVA,BAT_MITZVA,WEDDING_DATE,BRIT,AWARD}
    public enum ECategory {EVERY,HOME,STUDY,DESIGN,GARDEN,VOCATION, jewelry }*/

    public class Gift
    {
       [Key]
        public int GiftId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfViews { get; set; }
        public double StartingAge { get; set; }
        public double EndingAge { get; set;}
        public double EstimatedPrice { get; set; }
        public int GenderId { get; set; }
        public string Link { get; set; }
        public DateTime DateOfEntry { get; set; }
        public string ImageUrl { get; set; }
        public int EventsId { get; set; }
        public int CategryID { get; set; }
        public ICollection<Opinion> OpinionsList { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Events1 Events { get; set; }
        public Gender Gender { get; set; }
        public Categry Categry { get; set; }



    }
}
