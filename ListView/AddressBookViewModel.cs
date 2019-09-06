using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ListView
{

    public class AddressBookViewModel: IDisposable
    {
        private readonly IAddressFactory m_addressFactory;
        private readonly IAddressReadWriteFactory m_addressReadWriteFactory;
        private readonly string m_filepath;

        public AddressBookViewModel()
        {
            AddressBook = new ObservableCollection<IAddressInfo>();
            m_addressFactory = new AddressFactory();
            AddCachedAddressBook_(m_filepath); //initialize on construction
        }

        public IAddressInfo SelectedAddress { get; set; }

        public ObservableCollection<IAddressInfo> AddressBook { get; set; }


        #region ICommand ImplementationA

        public ICommand AddAddressCommand => new RelayCommand(param => AddAddressInfo_());

        public ICommand RemoveAddressCommand => new RelayCommand(param => RemoveAddress_(param));

        private void AddAddressInfo_()
		{
			AddressBook.Add(m_addressFactory.Create());
		}

        //no events subscribed to, so don't need to dispose
        private void RemoveAddress_(object param)
        {
            var address = param as AddressInfo;
            if(address != null)
            {
                SelectedAddress = address;
            }
  
            if(address != null)
            {
                AddressBook.Remove(SelectedAddress);
            }
        }

        #endregion


        #region Private Methods

        private void AddCachedAddressBook_(string path)
        {
            var cachedAddressBook = new List<IAddressInfo>();

            //might be null if user sets filename
            if(path == null)
            {
                return;
            }

            foreach(var address in cachedAddressBook)
            {
                AddressBook.Add(address);
            }
        }

        #endregion

        #region IDisposable Implementation

        public void Dispose()
        {
            foreach(var address in AddressBook)
            {
                address.Dispose();
            }
        }

        #endregion
    }
}
