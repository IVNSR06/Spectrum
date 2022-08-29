using System;
using System.Collections.Generic;
using Spectrum.Mobile.ViewModels;
using Xamarin.Forms;

namespace Spectrum.Mobile.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = App.ServiceProvider.GetService(typeof(HomePageViewModel));
        }
    }
}

