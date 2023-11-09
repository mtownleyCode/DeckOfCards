namespace DeckOfCardsAPI.Models
{
    public class Cards
    {
            public bool success { get; set; }
            public string deck_id { get; set; }
            public Card[] cards { get; set; }
            public int remaining { get; set; }

    }
}
