using System;
using System.Collections.Generic;

namespace KT_5
{
    public static class AlgorithmsKT5
    {
        public static int MaxSubarraySum(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return 0;
            }

            int maxSoFar = arr[0];
            int currentMax = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                int val = arr[i];
                if (currentMax + val > val)
                {
                    currentMax = currentMax + val;
                }
                else
                {
                    currentMax = val;
                }

                if (currentMax > maxSoFar)
                {
                    maxSoFar = currentMax;
                }
            }

            return maxSoFar;
        }

        public static List<int> GreedyMakeSum(int target, int[] denominations)
        {
            List<int> result = new List<int>();
            if (target <= 0 || denominations == null || denominations.Length == 0)
            {
                return result;
            }

            int[] sortedDenoms = (int[])denominations.Clone();
            Array.Sort(sortedDenoms);
            Array.Reverse(sortedDenoms);

            int remaining = target;
            for (int i = 0; i < sortedDenoms.Length; i++)
            {
                int coin = sortedDenoms[i];
                while (remaining >= coin)
                {
                    result.Add(coin);
                    remaining = remaining - coin;
                }
            }

            return result;
        }

        public static int MinCountDP(int target, int[] denominations)
        {
            if (target <= 0)
            {
                return 0;
            }

            int[] dp = new int[target + 1];
            for (int i = 1; i <= target; i++)
            {
                dp[i] = int.MaxValue;
            }

            dp[0] = 0;

            for (int i = 1; i <= target; i++)
            {
                for (int j = 0; j < denominations.Length; j++)
                {
                    int coin = denominations[j];
                    if (coin <= i)
                    {
                        int subRes = dp[i - coin];
                        if (subRes != int.MaxValue && subRes + 1 < dp[i])
                        {
                            dp[i] = subRes + 1;
                        }
                    }
                }
            }

            return dp[target] == int.MaxValue ? -1 : dp[target];
        }
    }
}
