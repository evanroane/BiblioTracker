﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using BiblioTrack.Model;
using System.Collections.ObjectModel;

namespace BiblioTrack.Repository
{
    public interface IVolumeRepository
    {
        int GetCount();
        void Add(Volume V);
        void DeleteVolume(Volume V);
        void UpdateVolume(Volume V);
        void Clear();
        ObservableCollection<Volume> All();
        Volume GetById(int id);
        IQueryable<Volume> SearchFor(Expression<Func<Volume, bool>> predicate);
    }
}