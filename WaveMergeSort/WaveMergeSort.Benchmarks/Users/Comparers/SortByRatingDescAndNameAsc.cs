using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace WaveMergeSort.Benchmarks.Users.Comparers
{
	public class SortByRatingDescAndNameAsc : IComparer<User>
	{
		public int Compare([AllowNull] User x, [AllowNull] User y)
		{
			if (x == null && y == null)
				return 0;
			if (x == null)
				return -1;
			if (y == null)
				return 1;

			int rating = -x.Rating.CompareTo(y.Rating);
			if (rating == 0)
			{
				return string.Compare(x.FullName, y.FullName);
			}

			return rating;
		}
	}
}
