using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Common.Models
{
	public abstract class Contact
	{
		// Fields
		protected int _id;
		protected string _name;
		protected string? _nickname;
		protected string _number;
		protected bool _isFavorite;
		// protected string[] _attributes = { "Name", "Nickname", "Number", "Favorite" };

		// Constructor
		public Contact() { }

		public Contact(int id, string name, string nickname, string number, string isFavorite)
		{
			Id = id;
			Name = name;
			Nickname = nickname;
			Number = number;
			if (isFavorite == "y")
			{
				IsFavorite = true;
			}
			else
			{
				IsFavorite = false;
			}
		}

		// Properties
		public int Id
		{
			get => _id;
			set => _id = value;
		}

		public string Name
		{
			get => _name;

			set
			{
				if (value == "" || value == null)
				{
					throw new ArgumentNullException("Contact Name can't be null.");
				}
				_name = value;
			}
		}

		public string Nickname
		{
			get => _nickname;
			set => _nickname = value;
		}

		public string Number
		{
			get => _number;

			set
			{
				if (value == "" || value == null)
				{
					throw new ArgumentNullException("Contact Number can't be null.");
				}
				_number = value;
			}
		}

		public bool IsFavorite
		{
			get => _isFavorite;
			set => _isFavorite = value;
		}

		// <<Abstract>>
		public abstract void ReceiveCall();
		public abstract void ShowContactDetails();

		// Compatibility Method
		// public void ConcatAttributesValues(string[] attr)
		// {
		// 	_attributes.Concat(attr);
		// }
	}
}