using BiblioTrack.Repository;
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

namespace BiblioTrack
{
    /// <summary>
    /// Interaction logic for EditVolume.xaml
    /// </summary>
    public partial class EditVolume : Window
    {
        //private VolumeRepository repo;
        private Model.Volume VolumeToEdit;
        public EditVolume(Model.Volume V)
        {
            InitializeComponent();
            VolumeToEdit = V;
            this.Edit_Author_First_Name.Text = V.authorFirstName;
            this.Edit_Author_Last_Name.Text = V.authorLastName;
            this.Edit_Volume_Title.Text = V.volumeTitle;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string auth_first_name = Edit_Author_First_Name.Text;
            string auth_last_name = Edit_Author_Last_Name.Text;
            string vol_title = Edit_Volume_Title.Text;
            var mainWindow = Application.Current.Windows
                .Cast<Window>()
                .FirstOrDefault(window => window is MainWindow) as MainWindow;
            mainWindow.repo.UpdateVolume(VolumeToEdit, auth_first_name, auth_last_name, vol_title);
            this.Hide();
            Edit_Author_First_Name.Text = "";
            Edit_Author_Last_Name.Text = "";
            Edit_Volume_Title.Text = "";
            mainWindow.ViewPort.DataContext = mainWindow.repo.All();
        }

    }
}
