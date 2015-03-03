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
using System.Collections;

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
        public ArrayList checked_list = new ArrayList();
        public MainWindow()
        {
            InitializeComponent();
            ViewPort.DataContext = repo.Context().Volumes.Local;
            add_volume_window = new AddVolume();
            //Category_Box.DataContext = repo.GetAllGenres();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            add_volume_window.Show();
        }


        private void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            if (ViewPort.SelectedItem == null)
            {
                return;
            }
            else
            {
                var selectedVolume = ViewPort.SelectedItem as Volume;
                Window edit_volume_window = new EditVolume(selectedVolume);
                edit_volume_window.Show();
            }
        }

        private void For_Sale_Checked(object sender, RoutedEventArgs e)
        {
            var selectedVolume = ViewPort.SelectedItem as Volume;
            repo.UpdateSaleStatus(selectedVolume, true);            
            //MessageBox.Show(
            //    string.Format(
            //        "You Checked - VolId: {0}, Last Name: {1}, Volume Title: {2}"
            //        , selectedVolume.volumeId, selectedVolume.authorLastName, selectedVolume.volumeTitle)
            //    );
        }

        private void For_Sale_UnChecked(object sender, RoutedEventArgs e)
        {
            var selectedVolume = ViewPort.SelectedItem as Volume;
            repo.UpdateSaleStatus(selectedVolume, false);

        }

        private void Select_Row_Checked(object sender, RoutedEventArgs e)
        {
            var selectedVolume = ViewPort.SelectedItem as Volume;
            int id = selectedVolume.volumeId;
            checked_list.Add(id);
        }

        private void Select_Row_UnChecked(object sender, RoutedEventArgs e)
        { 
            
        }

        private void Delete_Selected_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelected();
            checked_list.Clear();
        }

        private void DeleteSelected()
        {
            foreach (int id in checked_list)
            {
                repo.DeleteVolumeById(id);
            }
        }

    }
}
