using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListView
{
	public interface IAddressBook
	{
		string Address { get; set; }

		string Name { get; set; }

		string Number { get; set; }
	}
}
