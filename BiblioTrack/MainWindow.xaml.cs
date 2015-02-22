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

namespace BiblioTrack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public static VolumeRepository repo = new VolumeRepository();

        public MainWindow()
        {
            InitializeComponent();
            //repo.GetCount();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            var addVolume = new AddVolume();
            addVolume.Show();
        }

        private void Button_View_Click(object sender, RoutedEventArgs e)
        {
            var viewVolume = new ViewLibrary();
            viewVolume.Show();
        }
    }
}
