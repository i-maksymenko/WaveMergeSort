using System;
using System.Diagnostics.CodeAnalysis;

namespace WaveMergeSort.Benchmarks.Users
{
	public class User: IComparable<User>
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName => $"{FirstName} {LastName}".Trim();
		public int Rating { get; set; }

		public int CompareTo([AllowNull] User other)
		{
			if (other == null)
				return 1;

			return string.Compare(FullName, other.FullName);
		}
	}
}
