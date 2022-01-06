using System;
using System.Collections.Generic;
namespace Blackjack.Model
{
    public class Deck
    {
        private List<Card> CardsList { get; set; }
        public Queue<Card> Cards { get; private set; }
        public Deck()
        {
            CardsList = new List<Card>();
            Cards = new Queue<Card>();
            GetColdDeck();
            Shuffle();
            EnqueueCards();
        }

        private void GetColdDeck()
        {
            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (Faces face in Enum.GetValues(typeof(Faces)))
                {
                    CardsList.Add(new Card(face, suit));
                }
            }
        }

        private void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < CardsList.Count; i++)
            {
                int randomIndex = random.Next(0, CardsList.Count);
                Card card = CardsList[i];
                CardsList[i] = CardsList[randomIndex];
                CardsList[randomIndex] = card;
            }
        }

        private void EnqueueCards()
        {
            foreach (Card card in CardsList)
                Cards.Enqueue(card);
            CardsList.Clear();
        }
    }
}