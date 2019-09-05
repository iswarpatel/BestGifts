using System;
using System.Collections.Generic;
using System.IO;

namespace BestGifts
{
   /*
    * Program to choose 2 best gifts nearest to the given amount
    */
    class Program
    {
        static void Main(string[] args)
        {
            List<int> prices = new List<int>();
            List<string> items = new List<string>();
            string[] lines = File.ReadAllLines(args[0]);
            foreach (string line in lines)
            {
                string[] nums = line.Split(' ');
                string num = nums[nums.Length - 1];
                prices.Add(int.Parse(num));
                items.Add(line);
            }
            List<int> list = BestGifts(prices, int.Parse(args[1]));
            if (list[0] == -1)
            {
                Console.WriteLine("Not Possible");
            }
            else
            {
                Console.WriteLine(items[list[0]] + "," + items[list[1]]);
            }
            System.Threading.Thread.Sleep(10000);
        }

        /*
         * Main program. Assums that given list is in sorted order.
         */
        static List<int> BestGifts(List<int> options, int total)
        {
            int i = 0, j = options.Count - 1, x = -1, y = -1, bestSum = Int32.MinValue;
    
            while(i < j)
            {
                int sum = options[i] + options[j];
                if (sum == total) return new List<int> { i, j };
                else if (sum < total)
                {
                    if(sum > bestSum)
                    {
                        bestSum = sum;
                        x = i;
                        y = j;

                    }
                    i++;
                }
                else j--;
            }
            return new List<int> { x, y };
        }
    }
}
