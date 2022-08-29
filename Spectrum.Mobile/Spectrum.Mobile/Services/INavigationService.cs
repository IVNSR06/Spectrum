using System;
using System.Threading.Tasks;
using Spectrum.Mobile.ViewModels;

namespace Spectrum.Mobile.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;
    }
}

