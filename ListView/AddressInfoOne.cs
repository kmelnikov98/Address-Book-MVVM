using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListView
{
	public class AddressInfoOne: IAddressInfo //testing purposes
	{
		public AddressInfoOne(string address, string name, string num)
		: this()
		{
			Address = address;
			Name = name;
			Number = num;
		}

		public AddressInfoOne()
		{

		}

		public string Address { get; set; }

		public string Name { get; set; }

		public string Number { get; set; }

        public void WriteToAddressBook()
        {

        }

        public void Dispose()
        {

        }
	}
}

