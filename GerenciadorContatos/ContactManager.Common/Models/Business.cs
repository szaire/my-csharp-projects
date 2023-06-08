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

		public Business() : base() { }

		public Business( int id,
			string name,
			string nickname,
			string number,
			string isFavorite,
			string sectionNumber) : base(id, name, nickname, number, isFavorite)
		{
			BlockedNumbers = new List<Contact>();
			SectionNumber = sectionNumber;
			// ConcatAttributesValues(new string[] {"Section Number"});
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

		public List<Contact> BlockedNumbers
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
			foreach (Contact c in BlockedNumbers)
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