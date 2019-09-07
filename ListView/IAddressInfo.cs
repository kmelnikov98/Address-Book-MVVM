using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListView
{
	public interface IAddressInfo: IDisposable
	{
		string Address { get; set; }
		string Name { get; set; }
		string Number { get; set; }
        void WriteToAddressBook();

    }
}
