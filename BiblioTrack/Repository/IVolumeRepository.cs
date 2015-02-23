﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BiblioTrack.Model;

namespace BiblioTrack.Repository
{
    public interface IVolumeRepository
    {
        int GetCount();
        void Add(Volume V);
        void DeleteVolume(Volume V);
        void UpdateVolume(Volume V);
        void Clear();
        IEnumerable<Volume> All();
        Volume GetById(int id);
        IQueryable<Volume> SearchFor(Expression<Func<Volume, bool>> predicate);
    }
}