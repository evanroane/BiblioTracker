using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioTrack.Repository;
using BiblioTrack;

namespace BiblioTrack.Repository
{
    public class VolumeRepository : IVolumeRepository
    {
        private VolumeContext _dbContext;

        public VolumeRepository()
        {
            _dbContext = new VolumeContext();
            _dbContext.Volumes.Load();
        }

        public VolumeContext Context()
        {
            return _dbContext;
        }

        public DbSet<Model.Volume> GetDbSet()
        {
            return _dbContext.Volumes;
        }

        public int GetCount()
        {
            return _dbContext.Volumes.Count<Model.Volume>();
        }

        public ObservableCollection<Model.Volume> GetObservableVolumes()
        {
            return _dbContext.Volumes.Local;
        }

        public IQueryable<Model.Volume> SearchFor(System.Linq.Expressions.Expression<Func<Model.Volume, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        //Create
        public void Add(Model.Volume V)
        {
            _dbContext.Volumes.Add(V);
            _dbContext.SaveChanges();
        }

        //Read
        public List<Model.Volume> All()
        {
            var query = from Volume in _dbContext.Volumes
                        select Volume;
            return query.ToList<Model.Volume>();
            //return new ObservableCollection<Model.Volume>(query);
        }

        public int GetId(string authorFirstName, string authorLastName, string volumeTitle)
        {
            var query = from Volume in _dbContext.Volumes
                 where (Volume.authorFirstName == authorFirstName &&
                        Volume.authorLastName == authorLastName &&
                        Volume.volumeTitle == volumeTitle)
                        select Volume;
            return query.First<Model.Volume>().volumeId;
        }

        public Model.Volume GetById(int id)
        {
            var lq = from v in _dbContext.Volumes
                     where v.volumeId == id
                     select v;
            return lq.First<Model.Volume>();
        }

        //Update
        public void UpdateVolume(Model.Volume vol, string a, string b, string c)
        {
            vol.authorFirstName = a;
            vol.authorLastName = b;
            vol.volumeTitle = c;
            _dbContext.SaveChanges();
        }

        //Delete
        public void DeleteVolume(Model.Volume V)
        {
            _dbContext.Volumes.Remove(V);
            _dbContext.SaveChanges();
        }

        public void DeleteVolumeById(int id)
        {
            Model.Volume vol = GetById(id);
            DeleteVolume(vol);
        }

        public void Clear()
        {
            var a = this.All();
            _dbContext.Volumes.RemoveRange(a);
            _dbContext.SaveChanges();
        }
    }
}
