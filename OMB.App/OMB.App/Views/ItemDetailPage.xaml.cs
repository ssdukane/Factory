using OMB.App.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace OMB.App.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}