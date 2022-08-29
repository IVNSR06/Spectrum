using System;
using System.ComponentModel;
using Android.Content;
using Spectrum.Mobile.Controls;
using Spectrum.Mobile.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace Spectrum.Mobile.Droid.Renderer
{
    public class CustomPickerRenderer : Xamarin.Forms.Platform.Android.AppCompat.PickerRenderer
    {
        CustomPicker picker = null;

        public CustomPickerRenderer(Context context) : base(context)
        {
        }

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

        protected override void UpdatePlaceHolderText()
        {
            base.UpdatePlaceHolderText();
            UpdatePickerPlaceholder();
        }

        void UpdatePickerPlaceholder()
        {
            if (picker == null)
                picker = Element as CustomPicker;

            if (picker.Placeholder != null)
                Control.Hint = picker.Placeholder;
        }
    }
}

