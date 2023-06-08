using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Common.Models
{
	public class Standard : Contact
	{
		public Standard() : base() { }

		public Standard(int id,
			string name,
			string nickname,
			string number,
			string isFavorite) : base(id, name, nickname, number, isFavorite) { }

		public override void ReceiveCall()
		{
            Console.WriteLine($"The contact \"{Name}\" is receiving a call...");
		}

		public override void ShowContactDetails()
		{
			Console.WriteLine(ToString());
		}

		public override string ToString()
		{
			return (
				$"\tName: {Name}\n" +
				$"\tNickname: {Nickname}\n" +
				$"\tNumber: {Number}\n" +
				$"\tIs favorited? {IsFavorite}"
			);
		}
	}
}