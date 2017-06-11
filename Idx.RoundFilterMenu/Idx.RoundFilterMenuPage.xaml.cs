using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Idx.RoundFilterMenu
{
    public partial class Idx_RoundFilterMenuPage : ContentPage
    {
        public Idx_RoundFilterMenuPage()
        {
            InitializeComponent();

            Menu.ItemTapped += async (sender, e) =>
            {
                var evnt = (SelectedItemChangedEventArgs)e;
                Notifier.Text = (string)evnt.SelectedItem;
                await Task.Delay(2000);
                Notifier.Text = "";

            };
        }

    }
}
