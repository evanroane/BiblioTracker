﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

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
            var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\WPFSimpleTest\\bin\\Debug\\BiblioTrack");
            application = Application.Launch(applicationPath);
            window = application.GetWindow("MainWindow", InitializeOption.NoCache);

        }

        [TestMethod]
        public void TestZeroState()
        {
            Button left_button = window.Get<Button>("LeftButton");
            Button right_button = window.Get<Button>("RightButton");
            Button reset_button = window.Get<Button>("Reset");
            TextBox text_box = window.Get<TextBox>("CoolBox");

            Assert.IsTrue(left_button.Enabled);
            Assert.IsTrue(right_button.Enabled);
            Assert.IsTrue(text_box.IsReadOnly);
            Assert.AreEqual(text_box.Text, "");
            Assert.IsFalse(reset_button.Enabled);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            window.Close();
            application.Close();
        }
    }
}