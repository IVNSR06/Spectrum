using System;
using System.Collections.Generic;
using Spectrum.Mobile.ViewModels;
using Xamarin.Forms;

namespace Spectrum.Mobile.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = App.ServiceProvider.GetService(typeof(LoginPageViewModel));
        }
    }
}

