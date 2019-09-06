using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListView
{
	public class AddressReadWriteFactory : IAddressReadWriteFactory
    {
        public IAddressInfo Create(string path)
        {
        //    if (!File.Exists(path))
        //    {
        //        FileStream addressBookFile = File.Create(path);
        //    }

        //    File.WriteAllText(path, AddressInfo);

        //    //take path, parse list and then make multiple create values, make it into a list, then use AddRange inside the ViewModel to add to the AddressBook observableCollection...
            return new AddressInfo(); //test
        }
    }
}
