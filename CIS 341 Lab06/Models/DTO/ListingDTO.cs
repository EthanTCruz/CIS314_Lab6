using System.ComponentModel;

namespace CIS_341_Lab06.Models.DTO
{
    public class ListingDTO
    {

        public int StoreID { get; set; } // FK
        [DisplayName("Condition")]
        public string Condition { get; set; } // FK

        [DisplayName("Description")]
        public string Description { get; set; }
        public int Quantity { get; set; }


        // Navigation properties
        [DisplayName("Customer")]
        public string Customer { get; set; }
        [DisplayName("Store Name")]
        public string Store { get; set; }

    }
}
