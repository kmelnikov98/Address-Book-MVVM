using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ListView
{

    public class AddressBookViewModel
    {
        private readonly IAddressFactory m_addressFactory;

        public AddressBookViewModel()
        {
            AddressBooks = new ObservableCollection<IAddressBook>();
            m_addressFactory = new AddressFactory();

        }

        public IAddressBook SelectedAddress { get; set; }

        public ObservableCollection<IAddressBook> AddressBooks { get; set; }


        #region ICommand Implementation

        public ICommand AddAddressCommand => new RelayCommand(param => AddAddressInfo_());

        public ICommand RemoveAddressCommand => new RelayCommand(param => RemoveAddress_(param));

        private void AddAddressInfo_()
		{
			AddressBooks.Add(m_addressFactory.Create());
		}

        //no events subscribed to, so don't need to dispose
        private void RemoveAddress_(object param)
        {
            var address = param as AddressBook;
            if(address != null)
            {
                SelectedAddress = address;
            }
  
            if(address != null)
            {
                AddressBooks.Remove(SelectedAddress);
            }
        }

        #endregion
    }
}
