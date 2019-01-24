using System;
using System.Collections.Generic;
using System.Text;

namespace OopsPrograms
{
    class Card
    {
        string face;
        string suit;
        public Card(string cardFace,string cardSuit)
        {
            face = cardFace;
            suit = cardSuit;
        }
        public override string ToString()
        {
            return face + " of " + suit;
        }
    }
    class DeckOfCard
    {
        Card[] deck;
        int currentCard;
        const int NUMBER_OF_CARD = 36;
        Random ranNum;
        public DeckOfCard()
        {
            string[] faces = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "King", "Queen" };
            string[] suits = { "Hearts", "Clubs", "Diamonds", "Spades" };
            deck = new Card[NUMBER_OF_CARD];
            currentCard = 0;
            ranNum = new Random();
            for(int i = 0; i < deck.Length; i++)
            {
                deck[i] = new Card(faces[i % 11], suits[i / 13]);
            }
        }
        public void Shuffle()
        {
            currentCard = 0;
            for(int first = 0; first < deck.Length; first++)
            {
                int second = ranNum.Next(NUMBER_OF_CARD);
                Card temp = deck[first];
                deck[first] = deck[second];
                deck[second] = temp;
            }
        }
        public Card DealCard()
        {
            if (currentCard < deck.Length)
            {
                return deck[currentCard++];
            }
            else
            {
                return null;
            }
        }
        public void Execution()
        {
            DeckOfCard deckOfCard = new DeckOfCard();
            deckOfCard.Shuffle();
            for(int i = 0; i < 36; i++)
            {
                Console.Write("{0,-19}", deckOfCard.DealCard());
                if ((i + 1) % 4 == 0)
                {
                    Console.WriteLine();
                }
               
            }
        }
    }
}
