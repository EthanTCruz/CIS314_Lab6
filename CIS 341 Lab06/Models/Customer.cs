using System.ComponentModel;

namespace CIS_341_Lab06.Models
{
    public class Customer
    {
        [DisplayName("Customer ID")]
        public int CustomerID { get; set; } // PK
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }

        // Navigation properties
        public ICollection<Listing> CustomerListings { get; set; }
    }
}
