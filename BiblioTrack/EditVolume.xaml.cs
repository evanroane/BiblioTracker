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
        public EditVolume(Model.Volume V)
        {
            InitializeComponent();
            this.Edit_Author_First_Name.Text = V.authorFirstName;
            this.Edit_Author_Last_Name.Text = V.authorLastName;
            this.Edit_Volume_Title.Text = V.volumeTitle;
        }

    }
}
