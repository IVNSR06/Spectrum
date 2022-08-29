using System;
using Xamarin.Forms;

namespace Spectrum.Mobile.Controls
{
    public class CustomPicker : Picker
    {
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            nameof(Placeholder),
            typeof(string),
            typeof(string),
            string.Empty);

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty); 
            set => SetValue(PlaceholderProperty, value); 
        }
    }
}

