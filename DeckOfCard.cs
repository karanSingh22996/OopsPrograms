//-----------------------------------------------------------------------
// <copyright file="DeckOfCard.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;

    /// <summary>
    /// Card class is created to use card as a object
    /// </summary>
    public class DeckOfCard
    {
        /// <summary>
        /// Decks the card.
        /// </summary>
        public void DeckCard()
        {
            ////declaring and assigning the return value of card distribute method to player card array
            string[,] playercard = Utility.CardDistribute();
            ////printing on console
            Console.WriteLine("Player1 \t Player2 \t Player3 \t Player4");
            Console.WriteLine();
            int x = 0;
            int y = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(playercard[x, y] + " \t ");
                    y++;
                    if (y == 9)
                    {
                        y = 0;
                        x++;
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
