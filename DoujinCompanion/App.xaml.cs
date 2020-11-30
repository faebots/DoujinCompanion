using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DoujinDb;

namespace DoujinCompanion
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var dataPath = DoujinCompanion.Properties.Settings.Default.DataPath;
            if (string.IsNullOrEmpty(dataPath))
            {
                var window = new StartupScreen();
                window.Show();
            } else
            {
                DataContext.Init(dataPath);
                var window = new MainWindow();
                window.Show();
            }

        }
    }
}
