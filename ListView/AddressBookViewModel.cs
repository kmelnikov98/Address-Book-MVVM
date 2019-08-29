using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListView
{

	public class AddressBookViewModel
	{
		private readonly IAddressFactory m_addressFactory;
		public AddressBookViewModel()
		{
			AddressBooks = new ObservableCollection<IAddressBook>();
			m_addressFactory = new AddressFactory();

			for (int i = 0; i >= 0 && i < 5; i++)
			{
				Initialize_();
			}

			AddressBooks.Add(new AddressBookOne("Kirill", "43124", "4343"));
		}

		public ObservableCollection<IAddressBook> AddressBooks { get; set; }
	
		private void Initialize_()
		{
			AddressBooks.Add(m_addressFactory.Create("John", "543 6L8", "604-768-1995"));
		
		}



	}
}
