﻿using System.Diagnostics;
using Xamarin.Forms;

namespace VidyoConnector
{
    public partial class App : Application
    {
        IVidyoController _vidyoController = null;

        // Need this in order to see preview in App.xaml interface builder
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        public App(IVidyoController vidyoController)
        {
            InitializeComponent();
            MainPage mp = new MainPage();
            mp.Initialize(vidyoController);
            MainPage = mp;
            _vidyoController = vidyoController;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Debug.WriteLine("OnStart");
            ViewModel thisModel = ViewModel.GetInstance();
            thisModel.ClientVersion = "v " + _vidyoController.OnAppStart();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Debug.WriteLine("OnSleep");
            _vidyoController.OnAppSleep();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            Debug.WriteLine("OnResume");
            _vidyoController.OnAppResume();
        }
    }
}
