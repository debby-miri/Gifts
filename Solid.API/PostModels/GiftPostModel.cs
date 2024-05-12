using Gifts;
using Solid.Core.Entity;

namespace Solid.API.PostModels
{
    public class GiftPostModel
    {
       
      
      
     //   public User User { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double StartingAge { get; set; }        
        public double EndingAge { get; set; }
        public double EstimatedPrice { get; set; }
        public int Gender { get; set; }
        public string Link { get; set; }
        public string ImageUrl { get; set; }
        public int Events { get; set; }
        public int Categry { get; set; }        
        public int UserId { get; set; }

    }
}
