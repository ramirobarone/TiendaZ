using AppTiendaZ.ViewModels.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTiendaZ.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreguntasFrecuentes : ContentPage
    {
        public PreguntasFrecuentes()
        {
            InitializeComponent();
            BindingContext = new QuestionFrecuentlyViewModel(Navigation);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lst_QuestionFrecuently.SelectedItem != null)
            {
                lst_QuestionFrecuently.SelectedItem = null;
            }
        }
    }
}