﻿using Admin_MVVM.ViewModel;
using System.Windows;

namespace Admin_MVVM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new RegistrationVM();
        }
    }
}