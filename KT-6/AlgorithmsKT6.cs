using System;

namespace KT_6
{
    public class AlgorithmsKT6
    {
        public static (int, int)? FindPairWithSum(int[] sortedArr, int targetSum)
        {
            if (sortedArr == null || sortedArr.Length < 2)
            {
                return null;
            }

            int left = 0;
            int right = sortedArr.Length - 1;

            while (left < right)
            {
                int currentSum = sortedArr[left] + sortedArr[right];

                if (currentSum == targetSum)
                {
                    return (sortedArr[left], sortedArr[right]);
                }
                else if (currentSum < targetSum)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return null;
        }

        public static int MinSubarrayLength(int[] arr, int minSum)
        {
            if (arr == null || arr.Length == 0)
            {
                return 0;
            }

            int minLength = int.MaxValue;
            int currentSum = 0;
            int left = 0;

            for (int right = 0; right < arr.Length; right++)
            {
                currentSum += arr[right];

                while (currentSum >= minSum)
                {
                    int currentLength = right - left + 1;
                    if (currentLength < minLength)
                    {
                        minLength = currentLength;
                    }

                    currentSum -= arr[left];
                    left++;
                }
            }

            if (minLength == int.MaxValue)
            {
                return 0;
            }

            return minLength;
        }
    }
}
