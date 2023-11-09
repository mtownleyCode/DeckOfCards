namespace DeckOfCardsAPI.Models
{
    public class Card
    {
        public string image { get; set; }
        public string value { get; set; }
        public string suit { get; set; }
        public string code { get; set; }
        public bool isKept { get; set; }


        public static List<Card> cardList =new List<Card>();

        public static List<Card> keptCards = new List<Card>();

    }

}
