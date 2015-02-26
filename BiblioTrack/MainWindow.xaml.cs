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
        //public IEnumerable<Model.Volume> Volumes { get; set; }
        public static VolumeRepository repo { get; set; }
        public static ObservableCollection<Model.Volume> col; 
        public MainWindow()
        {
            InitializeComponent();
            repo = new VolumeRepository();
            col = repo.Context().Volumes.Local;
            //col = repo.All(); 
            ViewPort.DataContext = col;
            //ViewPort.DataContext = repo.Context().Volumes.Local;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            var addVolume = new AddVolume();
            addVolume.Show();
        }

    }
}
