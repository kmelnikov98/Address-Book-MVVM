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
        private readonly IAddressReadWrite m_addressReadWrite;
        private string m_filepath;

        public AddressBookViewModel()
        {
            m_filepath = @"C:\AddressBookApp\AddressBook.txt";
            m_addressReadWrite = new AddressReadWrite();
            AddressBook = new ObservableCollection<IAddressInfo>();
            m_addressFactory = new AddressFactory();
            AddCachedAddressBook_(m_filepath);
        }

        public IAddressInfo SelectedAddress { get; set; }

        public ObservableCollection<IAddressInfo> AddressBook { get; set; }


        #region ICommand ImplementationA

        public ICommand AddAddressCommand => new RelayCommand(param => AddAddressInfo_());

        public ICommand SaveCommand => new RelayCommand(param => Save_());

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


        #region Public Methods

        private void Save_()
        {
            if (File.Exists(m_filepath))
            {
                File.Delete(m_filepath);
            }

            foreach (var address in AddressBook)
            {
                address.WriteToAddressBook();
            }
        }

        #endregion

        #region Private Methods

        private void AddCachedAddressBook_(string path)
        {

            //might be null if user sets filename
            if (path == null)
            {
                return;
            }

            var count = m_addressReadWrite.AddressFileLineCount(path);
            
            for(int i = 0; i < count; i++)
            {
                AddressBook.Add(m_addressFactory.Create());
            }
            
            foreach(var address in AddressBook)
            {
                m_addressReadWrite.ReadFile(path, address);
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
