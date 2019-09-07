using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListView
{
	public interface IAddressFactory
	{
		IAddressInfo Create();
        IAddressInfo Create(string name, string address, string number);

    }
}
