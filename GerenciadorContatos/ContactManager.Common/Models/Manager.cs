using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Common.Models
{
	public class Manager
	{
		private int _index;
		private Dictionary<int, Contact> _contactList;

		public Manager()
		{
			Index = 0;
			ContactList = new Dictionary<int, Contact>();
		}

		public int Index
		{
			get => _index;
			set => _index = value;
		}

		public Dictionary<int, Contact> ContactList
		{
			get => _contactList;
			set => _contactList = value;
		}

		public void AddContact(Contact c)
		{
			ContactList.Add(Index, c);
			Index++;
		}

		

		public void ShowContactList()
		{
			foreach (var (index, contact) in ContactList)
			{
				Console.WriteLine($"Index: {index}");
				contact.ShowContactDetails();
			}
		}
	}
}