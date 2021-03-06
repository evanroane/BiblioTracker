﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiblioTrack;
using BiblioTrack.Model;
using BiblioTrack.Repository;
using System.Collections.ObjectModel;

namespace TestBiblioTrack
{
    /// <summary>
    /// Summary description for EventRepositoryTest
    /// </summary>
    [TestClass]
    public class VolumeRepositoryTest
    {
        private static VolumeRepository repo;

        [ClassInitialize]
        public static void SetUp(TestContext _context)
        {
            repo = new VolumeRepository();
            repo.Clear();
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            repo.Clear();
        }

        [TestCleanup]
        public void ClearDatabase()
        {
            repo.Clear();
        }

        [TestMethod]
        public void TestAddVolume()
        {
            Assert.AreEqual(0, repo.GetCount());
            repo.Add(new Volume("Tom", "Robbins", "Villa Incognito"));
            Assert.AreEqual(1, repo.GetCount());
        }

        [TestMethod]
        public void TestDeleteVolume()
        {
            repo.Clear();
            var vol = new Volume("Tom", "Robbins", "Villa Incognito"); 
            repo.Add(vol);
            Assert.AreEqual(1, repo.GetCount());
            repo.DeleteVolume(vol);
            Assert.AreEqual(0, repo.GetCount());
        }

        [TestMethod]
        public void TestGetVolumeById()
        {
            repo.Clear();
            repo.Add(new Volume("Tom", "Robbins", "Villa Incognito"));
            var all = repo.GetObservableVolumes()[0];
            Assert.AreEqual(all, repo.GetById(all.volumeId));
        }


        [TestMethod]
        public void TestAllMethod()
        {
            repo.Add(new Volume("Tom", "Robbins", "Villa Incognito"));
            repo.Add(new Volume("Plato", "Aristocles", "Symposium"));
            var all = repo.All();
            Assert.AreEqual(2, (all as List<Volume>).Count);

        }

        [TestMethod]
        public void TestGetCount()
        {
            repo.Clear();
            Assert.AreEqual(0, repo.GetCount());
            repo.Add(new Volume("Tom", "Robbins", "Villa Incognito"));
            Assert.AreEqual(1, repo.GetCount());
        }

        [TestMethod]
        public void TestClear()
        {
            repo.Clear();
            repo.Add(new Volume("Tom", "Robbins", "Villa Incognito"));
            Assert.AreEqual(1, repo.GetCount());
            repo.Clear();
            Assert.AreEqual(0, repo.GetCount());
        }

        [TestMethod]
        public void TestUpdateVolume()
        {
            repo.Clear();
            Volume vol = new Volume("Tom", "Smith", "Villa Incognito");
            repo.Add(vol);
            repo.UpdateVolume(vol, "Tom", "Robbins", "Villa Incognito");
            Assert.AreEqual("Robbins", vol.authorLastName.ToString());
        }
    }
}



