﻿using BeterSpellen.Data;
using BeterSpellen.Models;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeterSpellen
{
    public partial class App : Application
    {
        private static BeterSpellenDatabase database;

        public static BeterSpellenDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new BeterSpellenDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Constants.databaseName));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
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
