using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListView
{
	public interface IAddressFactory
	{
		IAddressBook Create();
		IAddressBook Create(string name, string address, string number);

	}
}
