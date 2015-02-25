﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.ListBoxItems;
using BiblioTrack.Repository;

namespace UITests
{
    [TestClass]
    public class UITests
    {
        private static TestContext test_context;
        private static Window window;
        private static Application application;
        public static VolumeRepository repo;

        [ClassInitialize]
        public static void Setup(TestContext _context)
        {
            repo = new VolumeRepository();
            repo.Clear();
            test_context = _context;
            var applicationDir = _context.DeploymentDirectory;
            var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\UITests\\bin\\Debug\\BiblioTrack");
            application = Application.Launch(applicationPath);
            window = application.GetWindow("BiblioTracker", InitializeOption.NoCache);
        }

        [TestMethod]
        public void TestMainWindowZeroState()
        {
            //Get elements for local refrence
            Button button_add = window.Get<Button>("Button_Add");
            TextBox box_total_volumes = window.Get<TextBox>("Box_Total_Volumes");
            TextBox box_for_sale = window.Get<TextBox>("Box_For_Sale");
            TextBox box_sold = window.Get<TextBox>("Box_Sold");
            TextBox box_total_volumes_num = window.Get<TextBox>("Box_Total_Volumes_Num");
            TextBox box_for_sale_num = window.Get<TextBox>("Box_For_Sale_Num");
            TextBox box_sold_num = window.Get<TextBox>("Box_Sold_Num");

            //Describe state of individual elements at zero state
            Assert.IsTrue(button_add.Enabled);
            Assert.IsTrue(box_total_volumes.IsReadOnly);
            Assert.IsTrue(box_for_sale.IsReadOnly);
            Assert.IsTrue(box_sold.IsReadOnly);
            Assert.IsTrue(box_total_volumes_num.IsReadOnly);
            Assert.IsTrue(box_for_sale_num.IsReadOnly);
            Assert.IsTrue(box_sold_num.IsReadOnly);

            //Contents of elements at zero state
            Assert.AreEqual(box_total_volumes.Text, "Total Volumes:");
            Assert.AreEqual(box_for_sale.Text, "For Sale:");
            Assert.AreEqual(box_sold.Text, "Sold:");
            Assert.AreEqual(box_total_volumes_num.Text, "0");
            Assert.AreEqual(box_for_sale_num.Text, "0");
            Assert.AreEqual(box_sold_num.Text, "0");
        }

        [ClassCleanup]
        public static void TearDown()
        {
            window.Close();
            application.Close();
        }
    }
}