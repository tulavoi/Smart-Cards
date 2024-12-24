using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCards.Interfaces;

namespace SmartCards.Controllers
{
    [Authorize]
    public class DeckController : Controller
    {
        //private readonly IDeckRepository _deckRepo;

        //public DeckController(IDeckRepository deckRepo)
        //{
        //    _deckRepo = deckRepo;
        //}

        public IActionResult Create()
        {

            return View();
        }
    }
}
