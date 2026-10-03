using System;

namespace KT_2
{
    public static class SearchAlgorithms
    {
        public static int BinarySearch(int[] sortedArr, int target)
        {
            if (sortedArr == null)
            {
                return -1;
            }

            int left = 0;
            int right = sortedArr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (sortedArr[mid] == target)
                {
                    return mid;
                }

                if (sortedArr[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }

        public static int LowerBound(int[] sortedArr, int target)
        {
            if (sortedArr == null)
            {
                return 0;
            }

            int left = 0;
            int right = sortedArr.Length;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (sortedArr[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

        public static int UpperBound(int[] sortedArr, int target)
        {
            if (sortedArr == null)
            {
                return 0;
            }

            int left = 0;
            int right = sortedArr.Length;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (sortedArr[mid] <= target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }
    }
}
