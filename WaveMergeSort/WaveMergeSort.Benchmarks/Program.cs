using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WaveMergeSort.Benchmarks.SortProviders.Extensions;
using WaveMergeSort.Benchmarks.Users;
using WaveMergeSort.Benchmarks.Users.Comparers;
using WaveMergeSort.Extensions;

namespace WaveMergeSort.Benchmarks
{
	class Program
	{
		static void Main(string[] args)
		{
			// get array size
			Console.WriteLine("Enter the size of array:");

			string arraySize = Console.ReadLine();
			int size;
			int.TryParse(arraySize?.Trim(), out size);
			if (size < 2)
			{
				size = 10;
			}
			// init comparers
			var comparers = new List<IComparer<User>>
			{
				new SortByNameAsc(),
				new SortByRatingDesc(),
				new SortByRatingDescAndNameAsc()
			};
			string comparersStr = string.Join(", ", comparers.Select((c, index) => $"{index} = {c.GetType().Name}").ToArray());
			// get comparer
			Console.WriteLine($"Select a comparer: {comparersStr}");

			string sortTypeStr = Console.ReadLine();
			int sortType;
			int.TryParse(sortTypeStr?.Trim(), out sortType);
			if (sortType >= comparers.Count || sortType < 0)
			{
				sortType = 0;
			}
			Console.WriteLine($"----------------------");
			// set comparer based on user choice
			IComparer<User> comparer = comparers[sortType];
			Console.WriteLine($"Comparer: {comparer.GetType().Name}");
			Console.WriteLine($"----------------------");
			// generate the list of users based on array size
			var users = UsersGenerator.GetUsers(size);
			// merge sort
			var arrForMergeSort = users.ToArray();
			var msStopWatch = new Stopwatch();
			msStopWatch.Start();
			arrForMergeSort.MergeSort(comparer);
			msStopWatch.Stop();
			Console.WriteLine($"Merge Sort: {msStopWatch.ElapsedMilliseconds}ms");
			// Tim sort
			var arrForTimSort = users.ToArray();
			var tsStopWatch = new Stopwatch();
			tsStopWatch.Start();
			arrForTimSort.TimSort(comparer);
			tsStopWatch.Stop();
			Console.WriteLine($"Timsort: {tsStopWatch.ElapsedMilliseconds}ms");
			// wave merge sort
			var arrForWaveMergeSort = users.ToArray();
			var wsStopWatch = new Stopwatch();
			wsStopWatch.Start();
			arrForWaveMergeSort.WaveMergeSort(comparer);
			wsStopWatch.Stop();
			Console.WriteLine($"Wave Merge Sort: {wsStopWatch.ElapsedMilliseconds}ms");
			// verify the Wave Merge Sort Stability
			Console.WriteLine($"Stable: {UsersGenerator.AreArraysEqual(arrForMergeSort, arrForWaveMergeSort)}");
			Console.WriteLine($"----------------------");
		}
	}
}
