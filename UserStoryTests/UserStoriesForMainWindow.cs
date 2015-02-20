//using System;
//using System.IO;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TestStack.White;
//using TestStack.White.Factory;
//using TestStack.White.UIItems;
//using TestStack.White.UIItems.WindowItems;
//using TestStack.BDDfy;
//using TestStack.White.UIItems.ListBoxItems;


//namespace UITests
//{
//    [TestClass]
//    public class StoryTests
//    {
//        //private static TestContext test_context;
//        private static Window window;
//        private static Application application;
//        private ComboBox combo_categories;
//        private Button button_view;
//        private Button button_add;
//        private TextBox box_total_volumes;
//        private TextBox box_for_sale;
//        private TextBox box_sold;
//        private TextBox box_total_volumes_num;
//        private TextBox box_for_sale_num;
//        private TextBox box_sold_num;

//        [ClassInitialize]
//        public static void Setup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _context)
//        {
//            var applicationDir = _context.DeploymentDirectory;
//            var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\UITests\\bin\\Debug\\BiblioTrack");
//            application = Application.Launch(applicationPath);
//            window = application.GetWindow("MainWindow", InitializeOption.NoCache);
//            //Elements:
//            ComboBox combo_categories = window.Get<ComboBox>("Combo_Categories");
//            Button button_view = window.Get<Button>("Button_View");
//            Button button_add = window.Get<Button>("Button_Add");
//            TextBox box_total_volumes = window.Get<TextBox>("Box_Total_Volumes");
//            TextBox box_for_sale = window.Get<TextBox>("Box_For_Sale");
//            TextBox box_sold = window.Get<TextBox>("Box_Sold");
//            TextBox box_total_volumes_num = window.Get<TextBox>("Box_Total_Volumes_Num");
//            TextBox box_for_sale_num = window.Get<TextBox>("Box_For_Sale_Num");
//            TextBox box_sold_num = window.Get<TextBox>("Box_Sold_Num");
//        }

//        // As a User
//        void GivenTheMainWindowisOpen()
//        {
//            Assert.IsTrue(window.IsFocussed);
//        }

//        void WhenTheAddVolumeButtonIsClicked()
//        {
//            System.Threading.Thread.Sleep(500); // So we can see it
//            button_add.Click();
//            System.Threading.Thread.Sleep(500); // So we can see it
//        }


//        //void ThenTheTextBoxShouldContainLeft()
//        //{
//        //    Assert.AreEqual("Left", text_box.Text);
//        //}

//        [TestMethod]
//        public void ExecuteStoryTest()
//        {
//            this.BDDfy();
//        }

//        [ClassCleanup]
//        public static void TearDown()
//        {
//            window.Close();
//            application.Close();
//        }
//    }
//}