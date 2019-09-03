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

        public List<IAddressInfo> Create(string path)
        {
            //take path, parse list and then make multiple create values, make it into a list, then use AddRange inside the ViewModel to add to the AddressBook observableCollection...
            return new List<IAddressInfo>(); //test
        }
    }
}
