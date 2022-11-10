using System.ComponentModel;

namespace CIS_341_Lab06.Models
{
    public class Store
    {
        [DisplayName("Store ID")]
        public int StoreID { get; set; } // PK
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; } 

        // Navigation properties
        public ICollection<Listing> StoreListings { get; set; }
    }
}
