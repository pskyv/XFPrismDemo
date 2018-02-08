using Xamarin.Forms;
using XFPrismDemo.Utils;

namespace XFPrismDemo.Views
{
    public partial class NoteListPage : ContentPage
    {
        public NoteListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send(this, Constants.OnNotesAppearingMsg);
        }
    }
}
