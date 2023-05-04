using System;
using System.Collections.Generic;
using System.Linq;
using WaveMergeSort.Helpers;

namespace WaveMergeSort.Benchmarks.SortProviders
{
	internal class MergeSort<T>
    {
        CompareHelper<T> _compareHelper;
        public void Sort(T[] arr, int left, int right, IComparer<T> comparer)
        {
            if (comparer == null && typeof(T).GetInterfaces().Contains(typeof(IComparable<T>)))
                comparer = Comparer<T>.Default;

            if (comparer == null)
                throw new InvalidOperationException($"Comparer is null, and one or more elements in array do not implement the System.IComparable<{typeof(T).Name}> generic interface");

            _compareHelper = new CompareHelper<T>(comparer);

            sortArray(arr, left, right);
        }
        private void sortArray(T[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                sortArray(arr, left, middle);
                sortArray(arr, middle + 1, right);

                merge(arr, left, middle, right);
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
