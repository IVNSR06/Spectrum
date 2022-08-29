using System;
using Microsoft.Extensions.DependencyInjection;
using Spectrum.Mobile.Services;
using Spectrum.Mobile.ViewModels;
using Spectrum.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Spectrum.Mobile
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public App ()
        {
            InitializeComponent();

            SetupServices();

            MainPage = new LoginPage();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }

        private void SetupServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ISpectrumService, SpectrumService>();
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddTransient<LoginPageViewModel>();
            services.AddTransient<HomePageViewModel>();
            services.AddTransient<ProductDetailPageViewModel>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}

