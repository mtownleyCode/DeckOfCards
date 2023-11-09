using DeckOfCardsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeckOfCardsAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int numberToDraw)
        {
            Card.cardList.Clear();

            if (Deck.currentDeck == null || Deck.currentDeck.remaining <= 0)
            {
                Deck.currentDeck = CardDAL.ShuffleDeck(Deck.currentDeck);
            }

            Deck.currentDeck.remaining = Deck.currentDeck.remaining - numberToDraw;

            Card.cardList = CardDAL.GetCards(Deck.currentDeck.deck_id, numberToDraw);

            Card.cardList = Card.cardList.Concat(Card.keptCards).ToList();

            ViewBag.CardList = Card.cardList;
            ViewBag.Deck = Deck.currentDeck;

            return View(Card.cardList);

        }

        public IActionResult KeepCards(List<Card> cardsToKeep)
        {
            Card.keptCards.Clear();

            for (int i = 0; i < cardsToKeep.Count; i++)
            {
                if (cardsToKeep[i].isKept)
                {
                    Card.keptCards.Add(Card.cardList[i]);
                    Card.cardList[i].isKept = true;
                }
            }

            return RedirectToAction("Index", new { numberToDraw = 0 });

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