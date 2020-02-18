using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MediaElementTest.Services;
using MediaElementTest.Views;

namespace MediaElementTest
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Device.SetFlags(new string[] { "MediaElement_Experimental" });
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
