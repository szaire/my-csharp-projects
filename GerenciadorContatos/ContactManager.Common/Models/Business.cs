using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Common.Models
{
	public class Business : Contact
	{
		private string? _sectionNumber;
		private List<Contact>? _blockedNumbers;

		public Business(string name, string number) : base(name, number) 
		{
			BlockedNumber = new List<Contact>();
		}

		public Business(string name, string number, string sectionNumber) : base(name, number) 
		{
			BlockedNumber = new List<Contact>();
			SectionNumber = sectionNumber;
		}

		public string SectionNumber
		{
			get => _sectionNumber;

			set
			{
				if (value == "")
				{
					_sectionNumber = null;
				}
				_sectionNumber = value;
			}
		}

		public List<Contact> BlockedNumber
		{
			get => _blockedNumbers;
			set => _blockedNumbers = value;
		}

		public override void ReceiveCall()
		{
			Console.WriteLine($"The business contact \"{Name}\" is receiving a call...");
		}

		public override void ShowContactDetails()
		{
			Console.WriteLine(ToString());
			Console.Write("\tBlocked Numbers: ");
			foreach (Contact c in BlockedNumber)
			{
				Console.Write($"{c.Number} ");
			}
			Console.WriteLine();
		}

		public override string ToString()
		{
			return (
				$"\tName: {Name}\n" +
				$"\tNickname: {Nickname}\n" +
				$"\tNumber: {Number}\n" +
				$"\tSection Number: {SectionNumber}\n" +
				$"\tIs favorited? {IsFavorite}"
			);
		}
	}
}