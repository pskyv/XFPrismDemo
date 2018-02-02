using CoreAnimation;
using CoreGraphics;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFPrismDemo.Controls;
using XFPrismDemo.iOS.CustomRenderers;

[assembly: ExportRenderer(typeof(EmptyValidationEntry), typeof(EmptyValidationEntryRenderer))]
namespace XFPrismDemo.iOS.CustomRenderers
{
    public class EmptyValidationEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            e.NewElement.TextChanged += NewElement_TextChanged;

            var element = (EmptyValidationEntry)this.Element;
            var textField = this.Control;

            textField.BorderStyle = UITextBorderStyle.None;
            CALayer bottomBorder = new CALayer
            {
                Frame = new CGRect(0.0f, element.HeightRequest - 1, this.Frame.Width, 1.0f),
                BorderWidth = 2.0f,
                BorderColor = element.LineColor.ToCGColor()
            };

            textField.Layer.AddSublayer(bottomBorder);
            textField.Layer.MasksToBounds = true;
        }

        private void NewElement_TextChanged(object sender, TextChangedEventArgs e)
        {
            CALayer bottomBorder = new CALayer
            {
                Frame = new CGRect(0.0f, ((EmptyValidationEntry)this.Element).HeightRequest - 1, this.Frame.Width, 1.0f),
                BorderWidth = 2.0f,
                BorderColor = string.IsNullOrEmpty(e.NewTextValue) ? new CGColor("Red") : new CGColor("Black")
            };

            Control.Layer.AddSublayer(bottomBorder);
            Control.Layer.MasksToBounds = true;
        }
    }
}
