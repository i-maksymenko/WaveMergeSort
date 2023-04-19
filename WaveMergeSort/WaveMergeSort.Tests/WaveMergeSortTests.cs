using Microsoft.VisualStudio.TestTools.UnitTesting;
using WaveMergeSort;

namespace WaveMergeSort.Tests
{
	[TestClass]
	public class WaveMergeSortTests
	{
		[TestMethod]
		public void SortedTest()
		{
			int[] given = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

			WaveMergeSort.Sort(given);
			Assert.IsTrue(AreArraysEqual(given, expected));
		}
		[TestMethod]
		public void ReverseSortedTest()
		{
			int[] given = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
			int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

			WaveMergeSort.Sort(given);
			Assert.IsTrue(AreArraysEqual(given, expected));
		}
		[TestMethod]
		public void RandomSortedTest()
		{
			int[] given = new int[] { 4, 3, 1, 9, 8, 2, 5, 7, 6 };
			int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

			WaveMergeSort.Sort(given);
			Assert.IsTrue(AreArraysEqual(given, expected));
		}

		private bool AreArraysEqual(int[] arr1, int[] arr2)
		{
			if (arr1 == null && arr2 == null)
				return true;

			if (arr1 == null)
				return false;

			if (arr2 == null)
				return false;

			if (arr1.Length != arr2.Length)
				return false;

			for (int i = 0; i < arr1.Length; i++)
			{
				if (arr1[i] != arr2[i])
					return false;
			}
			return true;
		}
	}
}
