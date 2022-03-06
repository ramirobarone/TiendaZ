using AppTiendaZ.ViewModels.MainBoard;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTiendaZ.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainBoard : ContentPage
    {
        public MainBoard()
        {
            InitializeComponent();
            BindingContext = new MainBoardViewModel(Navigation);
        }
    }
}