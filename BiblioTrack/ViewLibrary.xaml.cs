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
    /// Interaction logic for ViewLibrary.xaml
    /// </summary>
    public partial class ViewLibrary : Window
    {
        private VolumeRepository repo;
        public ViewLibrary()
        {
            InitializeComponent();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            repo = new VolumeRepository();
            var grid = sender as DataGrid;
            grid.ItemsSource = repo.All();
        }
    }
}
