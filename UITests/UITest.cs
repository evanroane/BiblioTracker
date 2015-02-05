﻿﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.ListBoxItems;

namespace UITests
{
    [TestClass]
    public class UITests
    {
        private static TestContext test_context;
        private static Window window;
        private static Application application;

        [ClassInitialize]
        public static void Setup(TestContext _context)
        {
            test_context = _context;
            var applicationDir = _context.DeploymentDirectory;
            var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\UITests\\bin\\Debug\\BiblioTrack");
            application = Application.Launch(applicationPath);
            window = application.GetWindow("BiblioTracker", InitializeOption.NoCache);

        }

        [TestMethod]
        public void TestZeroState()
        {
            //Get elements and store as local vars
            ComboBox combo_categories = window.Get<ComboBox>("Combo_Categories");
            //ComboBox item_all = window.Get<ComboBoxItem>("Item_All");
            Button button_view = window.Get<Button>("Button_View");
            Button button_add = window.Get<Button>("Button_Add");
            TextBox box_total_volumes = window.Get<TextBox>("Box_Total_Volumes");
            TextBox box_for_sale = window.Get<TextBox>("Box_For_Sale");
            TextBox box_sold = window.Get<TextBox>("Box_Sold");
            //ListItem listItem = new Li

            //State of elements at zero state
            Assert.IsTrue(button_view.Enabled);
            Assert.IsTrue(button_add.Enabled);
            Assert.IsTrue(combo_categories.Enabled);
            Assert.IsTrue(box_total_volumes.IsReadOnly);
            Assert.IsTrue(box_for_sale.IsReadOnly);
            Assert.IsTrue(box_sold.IsReadOnly);

            //Contents of elements at zero state
            Assert.AreEqual(box_total_volumes.Text, "Total Volumes:");
            Assert.AreEqual(box_for_sale.Text, "For Sale:");
            Assert.AreEqual(box_sold.Text, "Sold:");
            Assert.AreEqual(combo_categories.Item(0).Text, "All Items");
            Assert.AreEqual(combo_categories.Item(1).Text, "For Sale");
            Assert.AreEqual(combo_categories.Items[2].Text, "Sold");

            //Check that secondary windows are not initialized at zero state
        }

        [ClassCleanup]
        public static void TearDown()
        {
            window.Close();
            application.Close();
        }
    }
}