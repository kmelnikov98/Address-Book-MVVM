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

		public ObservableCollection<IAddressBook> AddressBooks { get; set; }

		public ICommand AddAddressCommand => new RelayCommand(param => AddAddressInfo_());

		private void AddAddressInfo_()
		{
			AddressBooks.Add(m_addressFactory.Create(m_name, m_address, m_number));

		}


		//TODO: Add a selected item. A selected item allows interaction with a specific element. For example, you can delete the item. 

	}
}
