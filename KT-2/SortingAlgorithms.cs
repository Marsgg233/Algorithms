using System;

namespace KT_2
{
    public static class SortingAlgorithms
    {
        public static void MergeSort(int[] arr, int left, int right)
        {
            if (arr == null)
            {
                return;
            }

            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        public static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArr = new int[n1];
            int[] rightArr = new int[n2];

            for (int i = 0; i < n1; i++)
            {
                leftArr[i] = arr[left + i];
            }

            for (int j = 0; j < n2; j++)
            {
                rightArr[j] = arr[mid + 1 + j];
            }

            int iIndex = 0;
            int jIndex = 0;
            int kIndex = left;

            while (iIndex < n1 && jIndex < n2)
            {
                if (leftArr[iIndex] <= rightArr[jIndex])
                {
                    arr[kIndex] = leftArr[iIndex];
                    iIndex++;
                }
                else
                {
                    arr[kIndex] = rightArr[jIndex];
                    jIndex++;
                }
                kIndex++;
            }

            while (iIndex < n1)
            {
                arr[kIndex] = leftArr[iIndex];
                iIndex++;
                kIndex++;
            }

            while (jIndex < n2)
            {
                arr[kIndex] = rightArr[jIndex];
                jIndex++;
                kIndex++;
            }
        }

        public static void QuickSort(int[] arr, int low, int high)
        {
            if (arr == null)
            {
                return;
            }

            if (low < high)
            {
                int pi = Partition(arr, low, high);
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        public static int Partition(int[] arr, int low, int high)
        {
            int mid = low + (high - low) / 2;

            if (arr[mid] < arr[low])
            {
                Swap(arr, low, mid);
            }
            if (arr[high] < arr[low])
            {
                Swap(arr, low, high);
            }
            if (arr[mid] < arr[high])
            {
                Swap(arr, mid, high);
            }

            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, high);
            return i + 1;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
