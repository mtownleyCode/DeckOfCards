namespace DeckOfCardsAPI.Models
{
    public class Deck
    {
        public string deck_id { get; set; }
        public bool shuffled { get; set; }
        public int remaining { get; set; }

        public static Deck currentDeck { get; set; }
    }

}
