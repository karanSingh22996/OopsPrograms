//-----------------------------------------------------------------------
// <copyright file="CardQueue.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Card queue class arrange the card in queue and in sorted order
    /// </summary>
    public class CardQueue
    {
        /// <summary>
        /// Cards the in queue.
        /// </summary>
        public void CardInQueue()
        {
            string[,] playercard = Utility.CardDistribute();

            Queue<Queue<string>> sortedcard = Utility.CardSort(playercard);
            string[] playername = { "Player 1", "Player 2", "Player 3", "Player 4" };
            int index = 0;
            while (sortedcard.Count != 0)
            {
                Queue<string> temp = sortedcard.Dequeue();
                Console.WriteLine(playername[index] + "--> ");
                while (temp.Count != 0)
                {
                    Console.Write(temp.Dequeue() + " \t ");
                }

                Console.WriteLine();
                index++;
            }
        }
    }
}
