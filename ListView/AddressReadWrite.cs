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
                using (StreamWriter addressBook = new StreamWriter(path))
                {
                    addressBook.WriteLine(addressInfo.Address);
                    addressBook.WriteLine(addressInfo.Name);
                    addressBook.WriteLine(addressInfo.Number);
                    addressBook.Close();
                }
            }
           else
           {
                using (StreamWriter addressBook = new StreamWriter(path, append: true))
                {

                    addressBook.WriteLine(addressInfo.Address);
                    addressBook.WriteLine(addressInfo.Name);
                    addressBook.WriteLine(addressInfo.Number);
                }
            }
        }

        public void ReadFile(string path, IAddressInfo addressInfo)
        {
            if (!File.Exists(path))
            {
                return;
            }

            if(AddressFileLineCount(path) == 0)
            {
                return;
            }

            StreamReader addressBook = new StreamReader(path);

            addressInfo.Address = addressBook.ReadLine();
            addressInfo.Name = addressBook.ReadLine();
            addressInfo.Number = addressBook.ReadLine();
            addressBook.Close();
        }

        public long AddressFileLineCount(string path)
        {
            if (!File.Exists(path))
            {
                return 0;
            }

            return (File.ReadLines(path).Count())/3;
        }
    }
}
