using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using CIS_341_Lab06.Data;
using CIS_341_Lab06.Models;
using CIS_341_Lab06.Models.DTO;

namespace CIS_341_Lab06.Controllers
{
    public class HomeController : Controller
    {
        private readonly CommunityStoreContext _context;


        public HomeController(CommunityStoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            /* Get all rows in Listings table as a list of Listing entities. 
             * Include related data through the navigation properties.
             * Uses eager loading to load related data. */
            List<Listing> listings = await _context.Listings
                .Include(listing => listing.Condition)
                .Include(listing => listing.Store)
                .ToListAsync();

            /* Uses explicit loading as separate queries. 
             * https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/read-related-data?view=aspnetcore-6.0#about-explicit-loading */
            foreach (Listing listing in listings)
            {
                /* Get the entity for each listing, reference through the navigation property 
                 * and explicitly load the related entities. */
                await _context.Entry(listing).Reference(l => l.Customer).LoadAsync();
            }

            // Turn the Listing entities into a DTOs for ease of use in the View.
            List<ListingDTO> listDTOs = new();
            foreach (Listing l in listings)
            {
                ListingDTO listingDTO = new()
                {

                    Quantity = l.Quantity,
                    Description = l.Description,
                    Customer = l.Customer.FirstName + " " + l.Customer.LastName,
                    Store = l.Store.Name,
                    Condition = l.Condition.Description
                };
                listDTOs.Add(listingDTO);
            }

            return View(listDTOs);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}