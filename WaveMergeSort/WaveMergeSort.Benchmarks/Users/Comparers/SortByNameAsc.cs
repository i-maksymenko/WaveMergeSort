using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace WaveMergeSort.Benchmarks.Users.Comparers
{
	public class SortByNameAsc : IComparer<User>
	{
		public int Compare([AllowNull] User x, [AllowNull] User y)
		{
			if (x == null && y == null)
				return 0;
			if (x == null)
				return -1;
			if (y == null)
				return 1;

			return string.Compare(x.FullName, y.FullName);
		}
	}
}
