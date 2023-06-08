using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ContactManager.Common.Models
{

	public class Manager
	{
		private const string DB_PATH = "DB";
		private const string CONTACTS_JSON = "Contacts.json";

		private int _index;
		private List<Contact> _contactList;
		private string[] _interfaceAttributes = new string[] { "Name", "Nickname", "Number", "Favorite (y/N)", "Section Number" };

		public Manager()
		{
			Index = 0;
			string list = File.ReadAllText($"../{DB_PATH}/{CONTACTS_JSON}");
			ContactList = JsonConvert.DeserializeObject(list);
			// ContactList = new List<Contact>();
		}

		public List<Contact> ContactList 
		{ 
			get => _contactList;
			set => _contactList = value;
		}

		// • PROPERTIES •
		public int Index
		{
			get => _index;
			set => _index = value;
		}

		// • Temporary PROPERTIES •
		// > Reduce the method scope variables created in
		// > menu methods
		public string? Temp_Name { get; set; }
		public string? Temp_Nickname { get; set; }
		public string? Temp_Number { get; set; }
		public string? Temp_FavoriteCondition { get; set; }
		public string? Temp_SectionNumber { get; set; }

		// • MENUS •
		public void PrintMenu()
		{
			Console.WriteLine("••••••Contact Menu••••••");
			Console.WriteLine("•  [1] Create contact  •");
			Console.WriteLine("•  [2] List contacts   •");
			Console.WriteLine("•  [3] Update contact  •");
			Console.WriteLine("•  [4] Delete contact  •");
			Console.WriteLine("•  [X] Quit            •");
			Console.WriteLine("••••••••••••••••••••••••");
			Console.Write("•> ");
		}

		public void SelectionMenu(string option, ref bool condition) 
		{
			switch (option)
			{
				case "1":
					AddContactMenu();
					break;
				case "2":
					// TODO: Create List Contacts Menu 
					break;
				case "3":
					// TODO: Create Update Contact Menu 
					break;
				case "4":
					// TODO: Create Delet Contact Menu 
					break;
				case "X":
				case "x":
					condition = false;
					break;
				default:
					Console.WriteLine(">> Invalid Option! Type any key to try again... <<");
					Console.ReadKey();
					break;
			}
		}

		public void AddContactMenu()
		{
			Console.Clear();

			// This variable will set the length of iteractions in the scope
			short iterationLength = 0;

			Console.WriteLine("•••••••Add Contact•••••••");
			Console.WriteLine("• Do you wish to Add a  •");
			Console.WriteLine("• Standard or Business  •");
			Console.WriteLine("• contact?              •");
			Console.WriteLine("• [1] Standard          •");
			Console.WriteLine("• [2] Business          •");
			Console.WriteLine("•••••••••••••••••••••••••");
			Console.Write("•> ");
			int contactType = Convert.ToInt32(Console.ReadLine());

			if (contactType != 1 && contactType != 2)
			{
				Console.WriteLine(">> Invalid Option! Type any key and try again... <<");
				throw new Exception(); // TODO: Specify this exception later...
			}
			if (contactType == 1)
			{
				iterationLength = 4;
			}
			else
			{
				iterationLength = 5;
			}

			Console.WriteLine("•••••••••••••••••••••••••");
			List<string?> attributesList = new List<string?>();
			Contact newContact = null;

			for (short i = 0; i < iterationLength; i++)
			{
				Console.Write($"••> {_interfaceAttributes[i]}: ");
				//DONE: Generalize this situation:
				// > Unfortunately, it won't be possible for this project structure
				attributesList.Add(Console.ReadLine());
			}

			Temp_Name = attributesList[0];
			Temp_Nickname = attributesList[1];
			Temp_Number = attributesList[2];
			Temp_FavoriteCondition= attributesList[3];

			if (contactType == 1)
			{
				newContact = new Standard(
					Index,
					Temp_Name,
					Temp_Nickname,
					Temp_Number,
					Temp_FavoriteCondition
				);
			}
			else {
				Temp_SectionNumber = attributesList[4];
				newContact = new Business(
					Index,
					Temp_Name,
					Temp_Nickname,
					Temp_Number,
					Temp_FavoriteCondition,
					Temp_SectionNumber
				);
			}

			AddContact(newContact);
			ResetTempVariables();
			AlterDB();
		}

		// • FUNCTIONAL METHODS •
		public void AddContact(Contact c)
		{
			ContactList.Add(c);
			Index++;
		}

		// TODO: Make Update Contact Method
		public void EditContact(int id) 
		{ 
			/* Implement method */ 
		}

		public void DeleteContact(int id)
		{
			Console.WriteLine($"Deleting contact \"{ContactList[id].Name}\"");
			ContactList.Remove(ContactList[id]);
		}

		public void ShowContactList()
		{
			foreach (var contact in ContactList)
			{
				Console.WriteLine($"({contact.Id}) - {contact.Name} ${(contact.Nickname != "" ? $"\"{contact.Nickname}\"" : "")} • {contact.Number}");
			}
		}

		public void ShowContactListDetails()
		{
			foreach (var contact in ContactList)
			{
				Console.WriteLine($"Index: {contact.Id}");
				contact.ShowContactDetails();
			}
		}

		public void ShowContactDetails(int id)
		{
			Contact contact = ContactList[id];			
			Console.WriteLine($"Index: {id}");
			contact.ShowContactDetails();
		}

		// • UTIL METHODS •
		private void ResetTempVariables()
		{
			Temp_Name = null;
			Temp_Nickname = null;
			Temp_Number = null;
			Temp_SectionNumber = null;
			Temp_FavoriteCondition = null;
		}

		// • DATABASE METHODS •
		private void AlterDB()
		{
			// TODO: Enhance the method with folder creation if non existent
			string serial_contact = JsonConvert.SerializeObject(ContactList, Formatting.Indented);
			File.WriteAllText("../DB/Contacts.json", serial_contact);
		}
	}
}