using System;
using System.ComponentModel;
using Spectrum.Mobile.Controls;
using Spectrum.Mobile.iOS.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace Spectrum.Mobile.iOS.Renderer
{
    public class CustomPickerRenderer : PickerRenderer
    {
        CustomPicker picker = null;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            picker = Element as CustomPicker;
            UpdatePickerPlaceholder();

            if (picker.SelectedIndex <= -1)
                UpdatePickerPlaceholder();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (picker == null)
                return;

            if (e.PropertyName.Equals(CustomPicker.PlaceholderProperty.PropertyName))
                UpdatePickerPlaceholder();
        }

        void UpdatePickerPlaceholder()
        {
            if (picker == null)
                picker = Element as CustomPicker;

            if (picker.Placeholder != null)
                Control.Placeholder = picker.Placeholder;
        }
    }
}

