using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListView
{
	public class AddressReadWrite : IAddressReadWrite
    {
        public void WriteFile(string path, IAddressInfo addressInfo)
        {
           if (!File.Exists(path))
           {
                FileStream addressBookFile = File.Create(path);
           }

            File.WriteAllText(path, addressInfo.Address);
            File.WriteAllText(path, addressInfo.Number);
            File.WriteAllText(path, addressInfo.Name);
        }
    }
}
