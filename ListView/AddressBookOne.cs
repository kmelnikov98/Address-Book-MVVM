using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListView
{
	public class AddressBookOne: IAddressBook
	{
		public AddressBookOne(string address, string name, string num)
		: this()
		{
			Address = address;
			Name = name;
			Number = num;
		}

		public AddressBookOne()
		{

		}

		public string Address { get; set; }

		public string Name { get; set; }

		public string Number { get; set; }
	}
}

