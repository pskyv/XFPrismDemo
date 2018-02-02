using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFPrismDemo.Controls;
using XFPrismDemo.Droid.CustomRenderers;

[assembly: ExportRenderer(typeof(EmptyValidationEntry), typeof(EmptyValidationEntryRenderer))]
namespace XFPrismDemo.Droid.CustomRenderers
{
    public class EmptyValidationEntryRenderer : EntryRenderer
    {
        public EmptyValidationEntryRenderer(Context context) : base(context) { }

        EmptyValidationEntry element;
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            e.NewElement.TextChanged += NewElement_TextChanged;

            element = (EmptyValidationEntry)this.Element;
            
            Control.Background.SetColorFilter(element.LineColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
        }

        private void NewElement_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                Control.Background.SetColorFilter(global::Android.Graphics.Color.Red, PorterDuff.Mode.SrcAtop);
            }
            else
            {
                Control.Background.SetColorFilter(global::Android.Graphics.Color.Black, PorterDuff.Mode.SrcAtop);
            }
        }
    }
}