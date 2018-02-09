using Xamarin.Forms;

namespace XFPrismDemo.Views
{
    public partial class TodoListPage : ContentPage
    {
        public TodoListPage()
        {
            InitializeComponent();
            lvItems.ItemTapped += LvItems_ItemTapped;
        }

        private void LvItems_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
