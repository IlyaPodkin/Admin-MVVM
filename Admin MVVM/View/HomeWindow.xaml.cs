using Admin_MVVM.ViewModel;
using System.Windows;

namespace Admin_MVVM.View
{
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
            this.DataContext = new HomeWindowVM();
        }
    }
}
