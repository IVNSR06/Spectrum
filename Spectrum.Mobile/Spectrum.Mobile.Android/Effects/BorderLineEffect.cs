using System;
using System.ComponentModel;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Spectrum.Mobile.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Spectrum")]
[assembly: ExportEffect(typeof(BorderLineEffect), "BorderLineEffect")]
namespace Spectrum.Mobile.Droid.Effects
{
    public class BorderLineEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            Android.Graphics.Color borderColor = Android.Graphics.Color.Red;

            if (Build.VERSION.SdkInt == BuildVersionCodes.Lollipop)
                Control.BackgroundTintList = ColorStateList.ValueOf(borderColor);

            else
                Control.Background.SetColorFilter(borderColor, PorterDuff.Mode.SrcOut);
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
        }
    }
}

