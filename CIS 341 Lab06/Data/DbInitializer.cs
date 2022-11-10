using CIS_341_Lab06.Models;

namespace CIS_341_Lab06.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CommunityStoreContext context)
        {
            context.Database.EnsureCreated();

            // OR use below if you want to use migrations
            // context.Database.Migrate();

            if(context.Listings.Any())
            {
                return;
            }

            // Create entity instances
            var customer = new Customer
            {
                FirstName = "Tomi",
                LastName = "Heimonen",
                Email = "theimone@uwsp.edu",
                Password = "12345" // BAD developer
            };

            // Add to DbSet
            context.Customers.Add(customer);

            var store = new Store
            {
                Name = "Dollar General",
                Address = "1234 Peach Street, 54495 Wisconsin Rapids, WI"
            };

            context.Stores.Add(store);

            store = new Store
            {
                Name = "Daly Drug",
                Address = "2345 5th Street, 54495 Wisconsin Rapids, WI"
            };

            context.Stores.Add(store);

            var condition = new Condition
            {
                Description = "New"
            };

            context.Conditions.Add(condition);

            var listing = new Listing
            {
                Condition = condition,
                Customer = customer,
                Store = store,
                Quantity = 1,
                Description = "Workbench"
            };

            context.Listings.Add(listing);
            // Commit changes
            context.SaveChanges();
        }
    }
}
