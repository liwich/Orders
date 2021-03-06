﻿using System;
using System.Collections.Generic;
using Orders.Views;
using Xamarin.Forms;

namespace Orders
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Helpers.Constants.InitializeServiceClient();

            MainPage = new NavigationPage(new Products());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
