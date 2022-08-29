using System;
using System.Collections.Generic;
using Spectrum.Mobile.ViewModels;
using Xamarin.Forms;

namespace Spectrum.Mobile.Views
{
    public partial class ProductDetailPage : ContentPage
    {
        public ProductDetailPage()
        {
            InitializeComponent();
            BindingContext = App.ServiceProvider.GetService(typeof(ProductDetailPageViewModel));
        }
    }
}

