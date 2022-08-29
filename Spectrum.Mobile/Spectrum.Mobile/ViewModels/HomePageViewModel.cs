using System;
using Spectrum.Mobile.Models;
using Spectrum.Mobile.Models.Response;
using Spectrum.Mobile.Services;
using System.Collections.ObjectModel;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Spectrum.Mobile.Helpers;
using System.Linq;
using System.Collections.Generic;

namespace Spectrum.Mobile.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<string> CategoryList { get; set; }

        public ObservableCollection<string> BrandList { get; set; }

        public ObservableCollection<string> AvailableCategoriesList { get; set; }

        public ObservableCollection<Product> ProductSortedFilteredList { get; set; }

        private string _welcomeMessage;
        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set => SetProperty(ref _welcomeMessage, value);
        }

        private string _categorySelected;
        public string CategorySelected
        {
            get => _categorySelected;
            set
            {
                SetProperty(ref _categorySelected, value);
                ProductSortedFilteredList.Clear();
                ProductList.Where(x => x.Category == value).ToList().ForEach(y => ProductSortedFilteredList.Add(y));
            }
        }

        private bool _isFilterAreaVisible;
        public bool IsFilterAreaVisible
        {
            get => _isFilterAreaVisible;
            set => SetProperty(ref _isFilterAreaVisible, value);
        }

        public List<Product> ProductList { get; set; }

        private ProductResponse _productResponse;
        public ProductResponse ProductResponse
        {
            get => _productResponse;
            set => SetProperty(ref _productResponse, value);
        }

        private User _user;
        public User User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public ICommand SelectProductCommand { get; }
        public ICommand FilterByCommand { get; }
        public ICommand SortByCommand { get; }

        public HomePageViewModel(ISpectrumService spectrumService, INavigationService navigationService) : base(spectrumService, navigationService)
        {
            User = new User();
            CategoryList = new ObservableCollection<string>();
            BrandList = new ObservableCollection<string>();
            ProductList = new List<Product>();
            ProductSortedFilteredList = new ObservableCollection<Product>();
            AvailableCategoriesList = new ObservableCollection<string>();
            SelectProductCommand = new Command(SelectProduct);
            FilterByCommand = new Command(FilterBy);
            SortByCommand = new Command(SortBy);
        }

        private void FilterBy() =>
            IsFilterAreaVisible = !IsFilterAreaVisible;

        private void SortBy()
        {
            ProductSortedFilteredList.Clear();
            ProductList.OrderBy(y => y.Price).ToList().ForEach(x => ProductSortedFilteredList.Add(x));
        }

        private async void SelectProduct(object obj)
        {
            var selectionChanged = obj as SelectionChangedEventArgs;
            await _navigationService.NavigateToAsync<ProductDetailPageViewModel>(selectionChanged);
        }

        public override async Task InitializeAsync(object parameter)
        {
            IsBusy = true;
            User = (User)parameter;
            WelcomeMessage = string.Format(Resources.WelcomeMessage, User.FirstName);
            var result = await _spectrumService.GetAsync<ProductResponse>(Constants.GetProducts);

            if (result.Products.Any())
            {
                result.Products.ForEach(x => ProductList.Add(x));
                result.Products.ForEach(x => ProductSortedFilteredList.Add(x));
                result.Products.Select(x => x.Category).Distinct().ToList().ForEach(y => AvailableCategoriesList.Add(y));
            }
            IsBusy = false;
        }
    }
}

