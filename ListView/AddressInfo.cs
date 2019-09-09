using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace ListView
{
    public delegate void VoidHandler();
    public class AddressInfo : IAddressInfo
    {
        private readonly IAddressReadWrite m_addressReadWrite;
        private string m_number;
        private string m_address;
        private string m_name;


        public AddressInfo(string name, string address, string number)
			: this()
		{
			m_address = address;
            m_name = name;
			m_number = number;
        }

		public AddressInfo()
        {
            m_addressReadWrite = new AddressReadWrite();
        }

        public string Address
        {
            get => m_address;
            set
            {
                if (m_address != value)
                {
                    m_address = value;
                }
            }
        }

        public string Name
        {
            get => m_name;
            set
            {
                if (m_name != value)
                {
                    m_name = value;
                }
            }
        }

        public string Number
        {
            get => m_number;
            set
            {
                if(m_number != value)
                {
                    m_number = value;
                }
            }
        }

        #region Private Methods



        public void WriteToAddressBook()
        {
            var path = @"C:\AddressBookApp\AddressBook.txt";

            if(m_address !=null && m_name != null && m_number != null)
            {
                m_addressReadWrite.WriteFile(path, this);
            }
        }

        #endregion


        #region IDisposable Implementation

        public void Dispose()
        {

        }

        #endregion
	}
}
