using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//not a static class, like FileOps, since its specific to the address class. 

namespace ListView
{
	public class AddressReadWrite : IAddressReadWrite
    {
        public void WriteFile(string path, IAddressInfo addressInfo)
        {
            StreamWriter addressBook = new StreamWriter(path, true);

            addressBook.WriteLine(addressInfo.Address);
            addressBook.WriteLine(addressInfo.Name);
            addressBook.WriteLine(addressInfo.Number);
            addressBook.Close();
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
            var file = File.ReadAllText(path);

            addressInfo.Address = addressBook.ReadLine();
            addressInfo.Name = addressBook.ReadLine();
            addressInfo.Number = addressBook.ReadLine();
            var AddressInfoText = new List<string> { addressInfo.Address, addressInfo.Name, addressInfo.Number };
            addressBook.Close();

            ReplaceTextInFile_(path, file, AddressInfoText);
        }

        public long AddressFileLineCount(string path)
        {
            if (!File.Exists(path))
            {
                return 0;
            }

            return (File.ReadLines(path).Count())/3;
        }

        private void ReplaceTextInFile_(string path, string file, List<string> values)
        {
            foreach(var value in values)
            {
                string pattern = @"([^\w]*" + value + @"[^\w]*)";
                string replacement = "";
                Regex rgx = new Regex(pattern);
                file = rgx.Replace(file, replacement, 1);
            }

            File.WriteAllText(path, file);

        }
    }
}
