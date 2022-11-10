using System.ComponentModel;

namespace CIS_341_Lab06.Models
{
    public class Type
    {
        [DisplayName("Type ID")]
        public int TypeID { get; set; } // PK
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }

        // Navigation properties
        public ICollection<Listing> ListingsByCollection { get; set; }
    }
}
