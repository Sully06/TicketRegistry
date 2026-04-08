using Microsoft.AspNetCore.Mvc;
using TicketSystem.Data;
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    public class TicketsController : Controller
    {
        private readonly TicketContext _context;

        public TicketsController(TicketContext context)
        {
            _context = context;
        }

        //displays all tickets
        public IActionResult Index()
        {
            List<Ticket> allTickets = _context.Tickets.ToList();
            return View(allTickets);
        }

        //shows the form to create a new ticket
        public IActionResult Create()
        {
            return View();
        }

        //saves the new ticket to the database
        [HttpPost]
        public IActionResult Create(Ticket newTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Tickets.Add(newTicket);
                int changesSaved = _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newTicket);
        }

        //invalidates a ticket (marks it as used)
        [HttpPost]
        public IActionResult Validate(int id)
        {
            Ticket? foundTicket = _context.Tickets.Find(id);

            if (foundTicket != null)
            {
                foundTicket.IsValid = false;
                int changesSaved = _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
