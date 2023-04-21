using System;

namespace WaveMergeSort
{
	/// <summary>
	/// The stable sorting method.
	/// </summary>
	public static class WaveMergeSort
	{
		/// <summary>
		/// Sorts the elements in the specified array.
		/// </summary>
		/// <param name="arr">The one-dimensional, zero-based array to sort.</param>
		public static void Sort(int[] arr)
		{
			Sort(arr, 0, arr.Length - 1);
		}

		/// <summary>
		/// Sorts the elements in a range of elements in the specified array.
		/// </summary>
		/// <param name="arr">The one-dimensional, zero-based array to sort.</param>
		/// <param name="left">The starting index of the range to sort.</param>
		/// <param name="right">The ending index of the range to sort.</param>
		public static void Sort(int[] arr, int left, int right)
		{
			int n = right - left + 1;
			if (n < 2)
				return;
			// init the array to store ending indices of waves
			int[] waves = new int[n / 3 + 2];
			// init waves counter
			int w = 0;
			// init a wave start index
			int l = left;
			// init a previous wave start index
			int p = left;
			// prepare waves for merging
			int i = left + 1;
			while (i <= right)
			{
				if (arr[i - 1] > arr[i])
				{
					// go down the wave
					while (i < right && arr[i] > arr[i + 1])
					{
						i++;
					}
					// reverse the current descent wave
					reverse(arr, l, i);
				}
				// climb up the wave
				while (i < right && arr[i] <= arr[i + 1])
				{
					i++;
				}
				// Try to merge last two small waves in place to reduce the number of waves.
				// The "6" is optimal number of elements to merge in place.
				// You can remove this block but you have to init "waves" array of length N/2 + 1.
				if (w > 0 && i - p < 6)
				{
					mergeInPlace(arr, p, l, i);
					w--;
				}
				else
				{
					p = l;
				}

				if (i < right)
				{
					// add a new wave's index
					waves[w++] = i;
					// set the next wave start
					l = ++i;
				}
				i++;
			}
			// merge the prepared waves
			for (int step = 1; step <= w; step = 2 * step)
			{
				// the starting index of the first wave
				l = left;
				for (i = step - 1; i < w; i += 2 * step)
				{
					// the ending index of the first wave
					int m = waves[i];
					// the index of the second wave
					p = i + step;
					// calculate the ending index of the second wave
					p = p < w ? waves[p] : right;
					// merge two waves
					merge(arr, l, m, p);
					// set the start of the next wave
					l = p + 1;
				}
			}
		}
		/// <summary>
		/// Reverses the sequence of the elements in a range of the specified array.
		/// </summary>
		/// <param name="arr">The one-dimensional, zero-based array to reverse.</param>
		/// <param name="left">The starting index of the range to reverse.</param>
		/// <param name="right">The ending index of the range to reverse.</param>
		private static void reverse(int[] arr, int left, int right)
		{
			int i = left;
			int j = right;
			while (i < j)
			{
				var tmp = arr[i];
				arr[i] = arr[j];
				arr[j] = tmp;
				i++;
				j--;
			}
		}
		/// <summary>
		/// Merges left and right sub-arrays in the specified array using the insertion sort.
		/// </summary>
		/// <param name="arr">The specified array to sort.</param>
		/// <param name="l">The starting index of the first range to merge.</param>
		/// <param name="l2">The starting index of the second range to merge.</param>
		/// <param name="r">The ending index of the second range to merge.</param>
		private static void mergeInPlace(int[] arr, int l, int l2, int r)
		{
			int i = l2;
			while (i <= r)
			{
				int temp = arr[i];
				int j = i;
				while (j > l && arr[j - 1] > temp)
				{
					arr[j] = arr[j - 1];
					j--;
				}
				if (j == i)
					return;

				arr[j] = temp;
				i++;
			}
		}
		/// <summary>
		/// Merges left and right sub-arrays in the specified array.
		/// </summary>
		/// <param name="arr">The specified array to sort.</param>
		/// <param name="l">The starting index of the first range to merge.</param>
		/// <param name="m">The ending index of the first range to merge.</param>
		/// <param name="r">The ending index of the second range to merge.</param>
		private static void merge(int[] arr, int l, int m, int r)
		{
			// the effective start index of the left wave
			int l2 = l;
			// the start index of the right wave
			int j = m + 1;
			// passing to an effective element in the left wave
			int tmp = arr[j];
			while (l2 <= m && arr[l2] <= tmp)
			{
				l2++;
			}
			// exit if there is no effective elements 
			if (l2 > m)
				return;
			// init the temp array for merging
			int[] temp = new int[r - l + 1];
			// the temp array counter
			int t = 0;
			// adding the first element of the right wave to the temp array
			temp[t++] = tmp;
			j++;
			// sorting waves into the temp array
			int i = l2;
			while (i <= m && j <= r)
			{
				if (arr[i] <= arr[j])
				{
					temp[t++] = arr[i++];
				}
				else
				{
					temp[t++] = arr[j++];
				}
			}
			// moving not affected elements from the left wave to the right
			int k = m + 1;
			while (k > i)
			{
				arr[--j] = arr[--k];
			}
			// copying the sorted elements from the temp array to the main one
			for (j = 0; j < t; j++)
			{
				arr[l2++] = temp[j];
			}
		}
	}
}
