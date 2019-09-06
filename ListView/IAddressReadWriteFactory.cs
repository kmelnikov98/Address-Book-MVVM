using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListView
{
	public interface IAddressReadWriteFactory
	{
        IAddressInfo Create(string path);
    }
}
