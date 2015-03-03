﻿using System;
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
        void DeleteVolumeById(int id);
        void UpdateVolume(Model.Volume vol, string a, string b, string c);
        void UpdateSaleStatus(Model.Volume vol, bool a);
        void Clear();
        List<Volume> All();
        Volume GetById(int id);
        //List<Volume> GetAllByGenre();
        IQueryable<Volume> SearchFor(Expression<Func<Volume, bool>> predicate);
    }
}