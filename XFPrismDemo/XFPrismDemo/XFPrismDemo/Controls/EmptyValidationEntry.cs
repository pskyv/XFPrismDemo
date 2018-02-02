using Xamarin.Forms;

namespace XFPrismDemo.Controls
{
    public class EmptyValidationEntry : Entry
    {
        public static readonly BindableProperty LineColorProperty =
            BindableProperty.Create(nameof(LineColor), typeof(Xamarin.Forms.Color), typeof(ImageEntry), Color.Black, BindingMode.TwoWay, null, propertyChanged: OnLineColorPropertyChanged);        

        public Color LineColor
        {
            get { return (Color)GetValue(LineColorProperty); }
            set { SetValue(LineColorProperty, value); }
        }

        private static void OnLineColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((ImageEntry)bindable).LineColor = (Color)newValue;
        }
    }
}
