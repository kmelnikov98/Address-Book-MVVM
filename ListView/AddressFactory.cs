using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListView
{
	public class AddressFactory: IAddressFactory
	{
		public IAddressBook Create(string name, string address, string number)
		{
			return new AddressBook(name, address, number);
		}
	}
}
