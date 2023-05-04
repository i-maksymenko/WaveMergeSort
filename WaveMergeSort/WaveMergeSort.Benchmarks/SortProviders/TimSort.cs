using System;
using System.Collections.Generic;
using System.Linq;
using WaveMergeSort.Helpers;

namespace WaveMergeSort.Benchmarks.SortProviders
{
	internal class TimSort<T>
    {
        CompareHelper<T> _compareHelper;

        public const int RUN = 32;
        
        public void Sort(T[] arr, int left, int right, IComparer<T> comparer)
        {
            if (comparer == null && typeof(T).GetInterfaces().Contains(typeof(IComparable<T>)))
                comparer = Comparer<T>.Default;

            if (comparer == null)
                throw new InvalidOperationException($"Comparer is null, and one or more elements in array do not implement the System.IComparable<{typeof(T).Name}> generic interface");

            _compareHelper = new CompareHelper<T>(comparer);

            for (int i = left; i <= right; i += RUN)
                insertionSort(arr, i, Math.Min(i + RUN - 1, right));

            for (int size = RUN; size <= right - left; size = 2 * size)
            {
                for (int l = left; l <= right; l += 2 * size)
                {
                    int m = l + size - 1;
                    int r = Math.Min(m + size, right);

                    if (m < r)
                        merge(arr, l, m, r);
                }
            }
        }
        private void insertionSort(T[] arr, int left, int right)
        {
            int i = left + 1;
            while (i <= right)
            {
                var temp = arr[i];
                int j = i;
                while (j > left && _compareHelper.GreaterThan(arr[j - 1], temp))
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                arr[j] = temp;
                i++;
            }
        }

        private void merge(T[] arr, int l, int m, int r)
        {
            int len1 = m - l + 1;
            int len2 = r - m;
            var left = new T[len1];
            var right = new T[len2];
            for (int x = 0; x < len1; x++)
            {
                left[x] = arr[l + x];
            }
            for (int x = 0; x < len2; x++)
            {
                right[x] = arr[m + 1 + x];
            }

            int i = 0;
            int j = 0;
            int k = l;

            while (i < len1 && j < len2)
            {
                if (_compareHelper.LessThanOrEqual(left[i], right[j]))
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < len1)
            {
                arr[k] = left[i];
                k++;
                i++;
            }

            while (j < len2)
            {
                arr[k] = right[j];
                k++;
                j++;
            }
        }

    }
}
