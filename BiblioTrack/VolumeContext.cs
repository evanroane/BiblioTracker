using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BiblioTrack.Model;

namespace BiblioTrack
{
    public class VolumeContext : DbContext
    {
        public DbSet<Volume> Volumes { get; set; }
    }
}
