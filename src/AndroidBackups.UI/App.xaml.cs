using AndroidBackups.UI.ViewModels;
using AndroidBackups.UI.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AndroidBackups.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var backuperViewModel = new BackuperViewModel();
            var window = new Backuper(backuperViewModel);
            window.Show();
        }


    }
}
