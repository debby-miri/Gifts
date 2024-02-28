using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gifts
{
    public enum EEvents {EVERY,BIRTHDAY,WEDDING,BAR_MITZVA,BAT_MITZVA,WEDDING_DATE,BRIT,AWARD}
    public enum ECategory {EVERY,HOME,STUDY,DESIGN,GARDEN,VOCATION }

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
        public bool Gender { get; set; }
        public string Link { get; set; }
        public DateTime DateOfEntry { get; set; }
        public string ImageUrl { get; set; }
        public EEvents Events { get; set; }
        public ECategory Categry { get; set; }
        public ICollection<Opinion> OpinionsList { get; set; }
        public User User { get; set; }
    }
}
