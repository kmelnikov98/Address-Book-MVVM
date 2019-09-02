using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListView
{
	public class AddressFactory: IAddressFactory
	{
		public IAddressInfo Create()
		{
			return new AddressInfo();
		}

		public IAddressInfo Create(string name, string address, string number)
		{
			return new AddressInfo(name, address, number);
		}
	}
}
