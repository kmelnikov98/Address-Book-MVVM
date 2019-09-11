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
        private readonly string m_defaultPath;

        public AddressBookViewModel()
        {
            m_defaultPath = @"C:\AddressPath.txt";
            m_addressReadWrite = new AddressReadWrite();
            AddressBook = new ObservableCollection<IAddressInfo>();
            m_addressFactory = new AddressFactory();
            AddCachedAddressBook_(FilePath);
        }

        public IAddressInfo SelectedAddress { get; set; }

        public ObservableCollection<IAddressInfo> AddressBook { get; set; }

        public string FilePath { get ; set; }


        #region ICommand ImplementationA

        public ICommand AddAddressCommand => new RelayCommand(param => AddAddressInfo_());

        public ICommand SaveCommand => new RelayCommand(param => Save_());

        public ICommand RemoveAddressCommand => new RelayCommand(param => RemoveAddress_(param));

        public ICommand ChooseFilePathCommand => new RelayCommand(param => ChooseFolder_());

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

        private void Save_()
        {
            if(FilePath == null)
            {
                return;
            }

            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            foreach (var address in AddressBook)
            {
                address.WriteToAddressBook(FilePath);
            }
        }

        private void ChooseFolder_()
        {
            FilePath = FileOps.SelectFileFolder() + @"\AddressBook.txt";
            FileOps.SaveFileLocation(m_defaultPath); //this is questionable, have to look further 
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
