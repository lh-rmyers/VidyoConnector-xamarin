﻿using Xamarin.Forms;

namespace VidyoConnector.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new VidyoConnector.App(VidyoController.GetInstance()));
        }
    }
}
