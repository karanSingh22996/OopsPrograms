using System;
using System.Collections.Generic;
using System.Text;

namespace OopsPrograms
{
    class Utility
    {
        public static string[,] cardDistribute()
        {
            String[,] arr =new String[4,13];
		cardInsert(arr);
        cardShuffle(arr);

        String[,] playercard =new String[4,9];
		for(int i=0;i<playercard.GetLength(0);i++)
		{
			for(int j=0;j<playercard.GetLength(1);j++)
			{
				playercard[i,j]=arr[i,j];
			}
        }
		return playercard;
	    }
        public static void cardInsert(String[,] arr)
        {
            String[] Suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
            String[] Rank = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "King", "Queen", "Ace" };

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i,j] = Suits[i] + " " + Rank[j];
                }
            }
        }
        public static void cardShuffle(String[,] arr)
        {
            Random r1 = new Random();
            for (int i = 0; i < 150; i++)
            {
                int x1 = Convert.ToInt32(r1.Next(4));
                int x2 = Convert.ToInt32(r1.Next(13));
                int x3 = Convert.ToInt32(r1.Next(4));
                int x4 = Convert.ToInt32(r1.Next(13));
                swap(arr, x1, x2, x3, x4);

            }
        }
        public static void swap(String[,] arr, int x1, int x2, int x3, int x4)
        {
            String temp = arr[x1,x2];
            arr[x1,x2] = arr[x3,x4];
            arr[x3,x4] = temp;
        }
        public static Queue<Queue<String>> cardSort(String[,] playercard)
        {
            Queue<Queue<String>> sortedcard = new Queue<Queue<String>>();

            String[] rank = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            int[] arr = new int[9];
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {

                    String[] temp = (playercard[i,j] + " ").Split(" ");
                    for (int k = 0; k < 13; k++)
                    {
                        if (temp[1].Equals(rank[k]))
                        {

                            arr[index] = k;
                            index++;
                        }
                    }
                }
                Console.WriteLine(); 
                index = 0;
                for (int k1 = 0; k1 < arr.Length - 1; k1++)
                {
                    for (int k2 = k1 + 1; k2 < arr.Length; k2++)
                    {
                        if (arr[k1] > arr[k2])
                        {
                            int temp = arr[k1];
                            arr[k1] = arr[k2];
                            arr[k2] = temp;

                            String temp1 = playercard[i,k1];
                            playercard[i,k1] = playercard[i,k2];
                            playercard[i,k2] = temp1;

                        }
                    }
                }

            }

            for (int i = 0; i < playercard.GetLength(0); i++)
            {
                Queue<String> temp = new Queue<string>();
                for (int j = 0; j < playercard.GetLength(1); j++)
                {
                    temp.Enqueue(playercard[i,j]);
                }
                sortedcard.Enqueue(temp);
            }

            return sortedcard;
        }
    }
}
