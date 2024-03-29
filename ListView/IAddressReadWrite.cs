﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListView
{
	public interface IAddressReadWrite
	{
        void WriteFile(string path, IAddressInfo addressInfo);
        void ReadFile(string path, IAddressInfo addressInfo);
        long AddressFileLineCount(string path);
    }
}
