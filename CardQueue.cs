using System;
using System.Collections.Generic;
using System.Text;

namespace OopsPrograms
{
    class CardQueue
    {
        public  void CardInQueue()
        {
            String[,] playercard = Utility.cardDistribute();

            Queue<Queue<String>> sortedcard = Utility.cardSort(playercard);
            String[] playername = { "Player 1", "Player 2", "Player 3", "Player 4" };
            int index = 0;
            while (sortedcard.Count!=0)
            {
                Queue<String> temp = sortedcard.Dequeue();
                Console.WriteLine(playername[index] + "--> ");
                while (temp.Count!=0)
                {
                    Console.Write(temp.Dequeue() + " \t ");
                }
                Console.WriteLine();
                index++;
            }

        }
    }
}
