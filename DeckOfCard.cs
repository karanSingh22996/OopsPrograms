//-----------------------------------------------------------------------
// <copyright file=" DeckOfCard.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;

    /// <summary>
    /// Card class is created to use card as a object
    /// </summary>
    public class Card
    {
        /// <summary>
        /// The face
        /// </summary>
        string face;

        /// <summary>
        /// The suit
        /// </summary>
        string suit;

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="cardFace">The card face.</param>
        /// <param name="cardSuit">The card suit.</param>
        public Card(string cardFace,string cardSuit)
        {
            ////Initializing instance variable face with cardFace passed at the time of creation of object
            face = cardFace;
            ////Initializing instance variable suit with cardSuit passed at the time of creation of object
            suit = cardSuit;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            ////Returning face of cards
            return face + " of " + suit;
        }
    }

    /// <summary>
    /// Deck class is created to perform every operation while suffling card
    /// </summary>
    public class DeckOfCard
    {
        /// <summary>
        /// The deck array
        /// </summary>
        Card[] deck;

        /// <summary>
        /// The current card
        /// </summary>
        int currentCard;

        /// <summary>
        /// The number of card
        /// </summary>
        const int NUMBER_OF_CARD = 36;

        /// <summary>
        /// The random number
        /// </summary>
        Random ranNum;
        /// <summary>
        /// Initializes a new instance of the <see cref="DeckOfCard"/> class.
        /// </summary>
        public DeckOfCard()
        {
            ////Creating and initializing faces array 
            string[] faces = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "King", "Queen" };
            ////creating and initializing suits array
            string[] suits = { "Hearts", "Clubs", "Diamonds", "Spades" };
            ////initilizing deck array with NUMBER_OF_CARD size
            deck = new Card[NUMBER_OF_CARD];
            ////initially we kept current array as zero
            currentCard = 0;
            ////creating object of random class
            ranNum = new Random();
            ////iterating till the length of deck
            for(int i = 0; i < deck.Length; i++)
            {
                ////assigning values to array using constructor of card
                deck[i] = new Card(faces[i % 11], suits[i / 13]);
            }
        }

        /// <summary>
        /// Shuffles this instance.
        /// </summary>
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
            Console.WriteLine("Player 1\t\t Player 2  \t Player 3\t Player 4 ");
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
