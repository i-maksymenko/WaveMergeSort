using System;
using System.Collections.Generic;

namespace WaveMergeSort.Benchmarks.SortProviders.Extensions
{
	public static class MergeSortExtensions
	{
		/// <summary>
		/// Sorts the elements in the specified array using the <see cref="IComparable" /> implementation of each element.
		/// </summary>
		/// <param name="arr">The one-dimensional, zero-based array to sort.</param>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		public static void MergeSort<T>(this T[] arr) where T : IComparable<T>
		{
			MergeSort(arr, 0, arr.Length - 1);
		}
		/// <summary>
		/// Sorts the elements in the specified array 
		/// using the specified <see cref="IComparer{T}" /> generic interface.
		/// </summary>
		/// <param name="arr">The one-dimensional, zero-based array to sort.</param>
		/// <param name="comparer">The <see cref="IComparer{T}" /> generic interface implementation to
		/// use when comparing elements.</param>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		public static void MergeSort<T>(this T[] arr, IComparer<T> comparer)
		{
			MergeSort(arr, 0, arr.Length - 1, comparer);
		}
		/// <summary>
		/// Sorts the elements in a range of elements in the specified array using the <see cref="IComparable" /> implementation of each element.
		/// </summary>
		/// <param name="arr">The one-dimensional, zero-based array to sort.</param>
		/// <param name="left">The starting index of the range to sort.</param>
		/// <param name="right">The ending index of the range to sort.</param>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		public static void MergeSort<T>(this T[] arr, int left, int right) where T : IComparable<T>
		{
			MergeSort(arr, left, right, Comparer<T>.Default);
		}

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
		public static void MergeSort<T>(this T[] arr, int left, int right, IComparer<T> comparer)
		{
			var mergeSort = new MergeSort<T>();
			mergeSort.Sort(arr, left, right, comparer);
		}
	}
}
