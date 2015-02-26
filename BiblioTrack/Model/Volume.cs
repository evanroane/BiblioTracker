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
        public string authorFirstNameValue;
        public string authorLastNameValue;
        public string volumeTitleValue;

        public event PropertyChangedEventHandler PropertyChanged;

        public Volume() { }

        // NOTE: after changing this.values, either migrate or wipe db
        public Volume(string afnv, string alnv, string vtv)
        {
            this.authorFirstNameValue = afnv;
            this.authorLastNameValue = alnv;
            this.volumeTitleValue = vtv;
        }

        public string AuthorFirstName
        {
            get { return authorFirstNameValue; }
            set
            {
                authorFirstNameValue = value;
                OnPropertyChanged("AuthorFirstName");
            }
        }

        public string AuthorLastName
        {
            get { return authorLastNameValue; }
            set
            {
                authorLastNameValue = value;
                OnPropertyChanged("AuthorLastName");
            }
        }

        public string VolumeTitle
        {
            get { return volumeTitleValue; }
            set
            {
                volumeTitleValue = value;
                OnPropertyChanged("AuthorFirstName");
            }
        }

        // Create the OnPropertyChanged method to raise the event 
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
