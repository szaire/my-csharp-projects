using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Common.Models
{
	public abstract class Contact
	{
		// Fields
		protected string _name;
		protected string? _nickname;
		protected string _number;
		protected bool _isFavorite;

		// Constructor
		public Contact(string name, string number)
		{
			Name = name;
			Number = number;
		}

		// Properties
		public string Name
		{
			get => _name;

			set
			{
				if (value == "" || value == null)
				{
					throw new ArgumentNullException("O nome do contato não pode ser vazio.");
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
					throw new ArgumentNullException("O númerto de contato não pode ser vazio.");
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
	}
}