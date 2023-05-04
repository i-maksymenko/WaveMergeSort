using System;
using System.Collections.Generic;

namespace WaveMergeSort.Helpers
{
	public class CompareHelper<T>
	{
		IComparer<T> _comparer;

		public CompareHelper(IComparer<T> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException(nameof(comparer));
			}
			_comparer = comparer;
		}

		public bool Equal(T x, T y) => _comparer.Compare(x, y) == 0;
		public bool GreaterThan(T x, T y) => _comparer.Compare(x, y) > 0;
		public bool GreaterThanOrEqual(T x, T y) => _comparer.Compare(x, y) >= 0;
		public bool LessThan(T x, T y) => _comparer.Compare(x, y) < 0;
		public bool LessThanOrEqual(T x, T y) => _comparer.Compare(x, y) <= 0;
	}
}
