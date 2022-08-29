using System;
using System.ComponentModel;
using Spectrum.Mobile.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Spectrum")]
[assembly: ExportEffect(typeof(BorderLineEffect), "BorderLineEffect")]
namespace Spectrum.Mobile.iOS.Effects
{
    public class BorderLineEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            Control.Layer.BorderColor = UIColor.Red.CGColor;
            Control.Layer.BorderWidth = new nfloat(0.8);
            Control.Layer.CornerRadius = 6;
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

