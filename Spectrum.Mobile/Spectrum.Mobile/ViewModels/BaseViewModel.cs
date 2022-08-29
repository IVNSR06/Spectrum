using System;
using Spectrum.Mobile.Services;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Spectrum.Mobile.ViewModels
{
    public abstract class BaseViewModel : BindableObject
    {
        public ISpectrumService _spectrumService;
        public INavigationService _navigationService;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        private bool _isErrorLabelVisible;
        public bool IsErrorLabelVisible
        {
            get => _isErrorLabelVisible;
            set => SetProperty(ref _isErrorLabelVisible, value);
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }


        public BaseViewModel(ISpectrumService spectrumService, INavigationService navigationService)
        {
            _spectrumService = spectrumService;
            _navigationService = navigationService;
        }

        public void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var name = GetMemberInfo(property).Name;
            OnPropertyChanged(name);
        }

        private MemberInfo GetMemberInfo(Expression expression)
        {
            MemberExpression operand;
            LambdaExpression lambdaExpression = (LambdaExpression)expression;
            if (lambdaExpression.Body as UnaryExpression != null)
            {
                UnaryExpression body = (UnaryExpression)lambdaExpression.Body;
                operand = (MemberExpression)body.Operand;
            }
            else
            {
                operand = (MemberExpression)lambdaExpression.Body;
            }
            return operand.Member;
        }

        public virtual Task InitializeAsync(object parameter)
        {
            return Task.FromResult(false);
        }
    }
}

