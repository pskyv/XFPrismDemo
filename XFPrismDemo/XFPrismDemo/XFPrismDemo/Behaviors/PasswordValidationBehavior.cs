using Xamarin.Forms;
using XFPrismDemo.Controls;

namespace XFPrismDemo.Behavior
{
    public class PasswordValidationBehavior : Behavior<EmptyValidationEntry>
    {
        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(PasswordValidationBehavior), true);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }

        protected override void OnAttachedTo(EmptyValidationEntry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;   
        }        

        protected override void OnDetachingFrom(EmptyValidationEntry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = !string.IsNullOrEmpty((sender as EmptyValidationEntry).Text) && ((sender as EmptyValidationEntry).Text).Length > 5;
            //(sender as EmptyValidationEntry).LineColor = IsValid ? Color.Default : Color.Red;
        }
    }
}
