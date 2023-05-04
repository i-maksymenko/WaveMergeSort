using System;
using System.Collections.Generic;

namespace WaveMergeSort.Benchmarks.Users
{
	public static class UsersGenerator
	{
		public static List<User> GetUsers(int count)
		{
			var users = new List<User>();
			var rand = new Random();
			for (int i = 0; i < count; i++)
			{
				users.Add(new User
				{
					Id = i + 1,
					FirstName = firstNames[rand.Next(0, firstNames.Length - 1)],
					LastName = lastNames[rand.Next(0, lastNames.Length - 1)],
					Rating = rand.Next(0, 10)
				});
			}
			return users;
		}

		public static bool AreArraysEqual(User[] arr1, User[] arr2)
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
				if (arr1[i].Id != arr2[i].Id)
					return false;
			}
			return true;
		}

		private static readonly string[] firstNames = new string[]
			{
				"Abigail",
				"Alexander",
				"Amelia",
				"Ava",
				"Barbara",
				"Bethany",
				"Callum",
				"Charles",
				"Charlie",
				"Charlotte",
				"Connor",
				"Damian",
				"Daniel",
				"David",
				"Elizabeth",
				"Emily",
				"Emma",
				"Ethan",
				"George",
				"Harry",
				"Isabella",
				"Isla",
				"Jack",
				"Jacob",
				"Jake",
				"James",
				"Jennifer",
				"Jessica",
				"Joanne",
				"Joe",
				"John",
				"Joseph",
				"Kyle",
				"Lauren",
				"Liam",
				"Lily",
				"Linda",
				"Madison",
				"Margaret",
				"Margaret",
				"Mary",
				"Mason",
				"Megan",
				"Mia",
				"Michael",
				"Michelle",
				"Noah",
				"Oliver",
				"Olivia",
				"Oscar",
				"Patricia",
				"Poppy",
				"Reece",
				"Rhys",
				"Richard",
				"Robert",
				"Samantha",
				"Sarah",
				"Sophia",
				"Sophie",
				"Susan",
				"Thomas",
				"Tracy",
				"Victoria",
				"William"
			};

		private static readonly string[] lastNames = new string[]
			{
				"Anderson",
				"Brown",
				"Byrne",
				"Davies",
				"Evans",
				"Gagnon",
				"Gelbero",
				"Johnson",
				"Jones",
				"Lam",
				"Lee",
				"Li",
				"Martin",
				"Morton",
				"Murphy",
				"O'Brien",
				"O'Connor",
				"O'Kelly",
				"O'Neill",
				"O'Ryan",
				"O'Sullivan",
				"Roberts",
				"Roy",
				"Singh",
				"Smith",
				"Taylor",
				"Thomas",
				"Tremblay",
				"Walsh",
				"Wang",
				"White",
				"Williams",
				"Wilson"
			};
	}
}
