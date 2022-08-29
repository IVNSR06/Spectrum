using System;
using Spectrum.Mobile.Services;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Spectrum.Mobile.Models.Request;
using Spectrum.Mobile.Models.Response;
using Spectrum.Mobile.Helpers;

namespace Spectrum.Mobile.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region Properties

        private LoginRequest _loginRequest;
        public LoginRequest LoginRequest
        {
            get => _loginRequest;
            set => SetProperty(ref _loginRequest, value);
        }

        public ICommand LoginCommand { get; }
        #endregion
        public LoginPageViewModel(ISpectrumService spectrumService, INavigationService navigationService) : base(spectrumService, navigationService)
        {
            LoginCommand = new Command(Login);
            LoginRequest = new LoginRequest();
        }

        private async void Login()
        {
            try
            {
                IsBusy = true;

                if (string.IsNullOrEmpty(LoginRequest.Username) || string.IsNullOrEmpty(LoginRequest.Password))
                {
                    IsErrorLabelVisible = true;
                    ErrorMessage = Resources.FieldRequired;
                    return;
                }

                var result = await _spectrumService.PostAsync<User>(LoginRequest, Constants.Login);

                if (result != null && !string.IsNullOrEmpty(result.Token))
                {
                    await _navigationService.NavigateToAsync<HomePageViewModel>(result);
                }
            }
            catch (Exception e)
            {
                IsErrorLabelVisible = true;
                ErrorMessage = e.Message;
                LoginRequest = null;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

