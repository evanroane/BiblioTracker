using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BiblioTrack.Model
{
    public class Volume : INotifyPropertyChanged
    {
        public int VolumeId { get; set; }
        public string AuthFirstName { get; set; }
        public string AuthLastName { get; set; }
        public string VolName { get; set; }

        public Volume()
        {
            // Place holder
        }

        public Volume(string AuthFirstName, string AuthLastName, string VolName)
        {
            this.AuthFirstName = AuthFirstName;
            this.AuthLastName = AuthLastName;
            this.VolName = VolName;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
