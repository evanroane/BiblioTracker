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
        public int volumeId { get; set; }
        public string authorFirstName { get; set; }
        public string authorLastName { get; set; }
        public string volumeTitle { get; set; }
        public bool forSale { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Volume() { }

        // NOTE: after changing this.values, either migrate or wipe db
        public Volume(string afn, string aln, string vt, bool fs)
        {
            this.authorFirstName = afn;
            this.authorLastName = aln;
            this.volumeTitle = vt;
            this.forSale = false;
        }

    }
}
