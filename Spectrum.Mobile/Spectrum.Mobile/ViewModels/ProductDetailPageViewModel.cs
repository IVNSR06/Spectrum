using System;
using Spectrum.Mobile.Models;
using Spectrum.Mobile.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace Spectrum.Mobile.ViewModels
{
    public class ProductDetailPageViewModel : BaseViewModel
    {
        private Product _product;

        public Product Product
        {
            get => _product;
            set => SetProperty(ref _product, value);
        }

        public ProductDetailPageViewModel(ISpectrumService spectrumService, INavigationService navigationService) : base(spectrumService, navigationService)
        {
            Product = new Product();
        }

        public override Task InitializeAsync(object parameter)
        {
            var demo = (SelectionChangedEventArgs)parameter;
            Product = (Product)demo.CurrentSelection.FirstOrDefault();
            return base.InitializeAsync(parameter);
        }
    }
}

