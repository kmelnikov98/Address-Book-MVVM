using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ListView
{

	public class AddressBookViewModel
	{
		private readonly IAddressFactory m_addressFactory;
		private string m_number;
		private string m_name;
		private string m_address;

		public AddressBookViewModel()
		{
			AddressBooks = new ObservableCollection<IAddressBook>();
			m_addressFactory = new AddressFactory();

		}


		public string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}

		public string Number
		{
			get { return m_number; }
			set { m_number = value; }
		}

		public string Address
		{
			get { return m_address; }
			set { m_address = value; }
		}

		public ObservableCollection<IAddressBook> AddressBooks { get; set; }

		public ICommand AddAddressCommand => new RelayCommand(param => AddAddressInfo_());

		private void AddAddressInfo_()
		{
			AddressBooks.Add(m_addressFactory.Create(m_name, m_address, m_number));

		}



	}
}
