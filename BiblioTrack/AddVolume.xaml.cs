using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BiblioTrack.Repository;
using BiblioTrack.Model;

namespace BiblioTrack
{
    /// <summary>
    /// Interaction logic for AddVolume.xaml
    /// </summary>
    public partial class AddVolume : Window
    {
        private VolumeRepository repo;
        private Volume vol;
        public AddVolume()
        {
            InitializeComponent();
            repo = new VolumeRepository();
        }

        private void Save_Vol_Click(object sender, RoutedEventArgs e)
        {
            string auth_first_name = Auth_First_Name.Text;
            string auth_last_name = Auth_Last_Name.Text;
            string vol_title = Vol_Title.Text;
            bool for_sale = false;
            vol = new Volume(auth_first_name, auth_last_name, vol_title, for_sale);
            var mainWindow = Application.Current.Windows
                .Cast<Window>()
                .FirstOrDefault(window => window is MainWindow) as MainWindow;
            mainWindow.repo.Add(vol);
            this.Hide();
            Auth_First_Name.Text = "";
            Auth_Last_Name.Text = "";
            Vol_Title.Text = "";
        }
    }
}
