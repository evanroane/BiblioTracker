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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using BiblioTrack;
using BiblioTrack.Model;
using BiblioTrack.Repository;
using System.Collections.ObjectModel;

namespace BiblioTrack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public VolumeRepository repo = new VolumeRepository();
        public static ObservableCollection<Model.Volume> col;
        public AddVolume add_volume_window;
        //public EditVolume edit_volume_window;
        public MainWindow()
        {
            InitializeComponent();
            ViewPort.DataContext = repo.Context().Volumes.Local;
            add_volume_window = new AddVolume();
            //edit_volume_window = new EditVolume();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            add_volume_window.Show();
        }


        private void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            if (ViewPort.SelectedItem == null) return;
            var selectedVolume = ViewPort.SelectedItem as Volume;
            Window edit_volume_window = new EditVolume(selectedVolume);
            edit_volume_window.Show();

            //MessageBox.Show(
            //    string.Format(
            //        "The Volume you double clicked on is - First Name: {0}, Last Name: {1}, Volume Title: {2}"
            //        , selectedVolume.authorFirstName, selectedVolume.authorLastName, selectedVolume.volumeTitle)
            //    );
        }

    }
}
