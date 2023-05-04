using System;
using System.Collections.Generic;
using System.Linq;
using WaveMergeSort.Helpers;

namespace WaveMergeSort
{
	/// <summary>
	/// The stable sorting method.
	/// </summary>
	internal class WaveMergeSort<T>
	{
		CompareHelper<T> _compareHelper;

		/// <summary>
		/// Sorts the elements in a range of elements in the specified array
		/// using the specified <see cref="IComparer{T}" /> generic interface.
		/// </summary>
		/// <param name="arr">The one-dimensional, zero-based array to sort.</param>
		/// <param name="left">The starting index of the range to sort.</param>
		/// <param name="right">The ending index of the range to sort.</param>
		/// <param name="comparer">The <see cref="IComparer{T}" /> generic interface implementation to
		/// use when comparing elements.</param>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		public void Sort(T[] arr, int left, int right, IComparer<T> comparer)
		{
			if (comparer == null && typeof(T).GetInterfaces().Contains(typeof(IComparable<T>)))
				comparer = Comparer<T>.Default;

			if (comparer == null)
				throw new InvalidOperationException($"Comparer is null, and one or more elements in array do not implement the System.IComparable<{typeof(T).Name}> generic interface");

			_compareHelper = new CompareHelper<T>(comparer);

			SortWaves(arr, left, right);
		}
		private void SortWaves(T[] arr, int left, int right)
		{
			int n = right - left + 1;
			if (n < 2)
				return;

			// init the array to store ending indices of waves
			int[] waves = new int[n / 2 + 1];
			// init waves counter
			int w = 0;
			// init a wave start index
			int l;
			// init a wave end index
			int r = left;
			// prepare waves for merging
			while (r < right)
			{
				if (_compareHelper.GreaterThan(arr[r], arr[++r]))
				{
					l = r - 1;
					// go down the wave
					while (r < right && _compareHelper.GreaterThan(arr[r], arr[r + 1]))
					{
						r++;
					}
					// reverse the current descent wave
					reverse(arr, l, r);
				}
				// climb up the wave
				while (r < right && _compareHelper.LessThanOrEqual(arr[r], arr[r + 1]))
				{
					r++;
				}
				// save the wave's end index
				waves[w++] = r++;
			}
			if (w > 0 && waves[w - 1] == right)
			{
				w--;
			}
			mergeWaves(arr, left, right, waves, 0, w);
		}
		/// <summary>
		/// Merges sorted sub-arrays of main array recursively.
		/// </summary>
		/// <param name="arr">The one-dimensional, zero-based array to sort.</param>
		/// <param name="left">The starting index of the range to sort.</param>
		/// <param name="right">The ending index of the range to sort.</param>
		/// <param name="waves">The one-dimensional, zero-based array of waves.</param>
		/// <param name="waveStart">The left wave to merge.</param>
		/// <param name="waveEnd">The right wave to merge.</param>
		private void mergeWaves(T[] arr, int left, int right, int[] waves, int waveStart, int waveEnd)
		{
			if (waveStart < waveEnd)
			{
				int waveMiddle = waveStart + (waveEnd - waveStart) / 2;
				int middle = waves[waveMiddle];

				mergeWaves(arr, left, middle, waves, waveStart, waveMiddle);
				mergeWaves(arr, middle + 1, right, waves, waveMiddle + 1, waveEnd);

				merge(arr, left, middle, right);
			}
		}
		/// <summary>
		/// Reverses the sequence of the elements in a range of the specified array.
		/// </summary>
		/// <param name="arr">The one-dimensional, zero-based array to reverse.</param>
		/// <param name="left">The starting index of the range to reverse.</param>
		/// <param name="right">The ending index of the range to reverse.</param>
		private void reverse(T[] arr, int left, int right)
		{
			int i = left;
			int j = right;
			do
			{
				var tmp = arr[i];
				arr[i] = arr[j];
				arr[j] = tmp;
				i++;
				j--;
			} 
			while (i < j);
		}
		/// <summary>
		/// Merges left and right sub-arrays in the specified array.
		/// </summary>
		/// <param name="arr">The specified array to sort.</param>
		/// <param name="l">The starting index of the first range to merge.</param>
		/// <param name="m">The ending index of the first range to merge.</param>
		/// <param name="r">The ending index of the second range to merge.</param>
		private void merge(T[] arr, int l, int m, int r)
		{
			int len1 = m - l + 1;
			int len2 = r - m;
			var left = new T[len1];
			var right = new T[len2];
			int i;
			int k = l;

			for (i = 0; i < len1; i++)
			{
				left[i] = arr[k++];
			}

			for (i = 0; i < len2; i++)
			{
				right[i] = arr[k++];
			}

			i = 0;
			int j = 0;
			k = l;

			while (i < len1 && j < len2)
			{
				if (_compareHelper.GreaterThan(left[i], right[j]))
				{
					arr[k++] = right[j++];
				}
				else
				{
					arr[k++] = left[i++];
				}
			}

			while (i < len1)
			{
				arr[k++] = left[i++];
			}

			while (j < len2)
			{
				arr[k++] = right[j++];
			}
		}

	}
}
