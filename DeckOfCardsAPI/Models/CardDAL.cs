using RestSharp;


namespace DeckOfCardsAPI.Models
{
    public class CardDAL
    {
        public static string baseURL { get; set; } = @"https://deckofcardsapi.com/api/deck/";

        public static Deck ShuffleDeck(Deck deck)
        {
            string endpoint = @"new/shuffle/?deck_count=1";

            RestClient client = new RestClient(baseURL + endpoint);
            RestRequest request = new RestRequest();
                        
            deck = client.Get<Deck>(request);

            return deck;

        }

        public static List<Card> GetCards(string deckId, int cardCount)
        {           

            string endpoint = @$"{ deckId }/draw/?count={ cardCount }";

            RestClient client = new RestClient(baseURL + endpoint);
            RestRequest request = new RestRequest();

            Cards topLevel = client.Get<Cards>(request);            

            List<Card> cards = topLevel.cards.ToList();

            return cards;

        }

    }
}
