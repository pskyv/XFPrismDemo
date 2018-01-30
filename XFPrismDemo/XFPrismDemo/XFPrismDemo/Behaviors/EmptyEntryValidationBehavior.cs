using Xamarin.Forms;
using XFPrismDemo.Controls;

namespace XFPrismDemo.Behavior
{
    public class EmptyEntryValidationBehavior : Behavior<ImageEntry>
    {
        protected override void OnAttachedTo(ImageEntry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(ImageEntry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            (sender as ImageEntry).LineColor = string.IsNullOrEmpty((sender as ImageEntry).Text) ? Color.Red : Color.Default;
            (sender as ImageEntry).PlaceholderColor = string.IsNullOrEmpty((sender as ImageEntry).Text) ? Color.Red : Color.Default;            
        }
    }
}
