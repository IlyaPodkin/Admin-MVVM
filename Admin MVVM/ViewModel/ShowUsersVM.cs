using Admin_MVVM.Model.Data;
using Admin_MVVM.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_MVVM.ViewModel
{
    public class ShowUsersVM : ViewModelBase
    {
        private List<User> _allUsers = DataUser.GetAllUsers();

        public List<User> AllUsers { 
            get { return _allUsers; }
            set 
            { 
                _allUsers = value;
                OnPropertyChanged(nameof(AllUsers));
            }
        }
    }
}
