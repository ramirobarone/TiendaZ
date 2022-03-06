using AppTiendaZ.Models.Menu;
using AppTiendaZ.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTiendaZ.ViewModels.Menu
{
    public class QuestionFrecuentlyViewModel : BaseViewModel
    {
        private ObservableCollection<PreguntasFrecuente> _PreguntasFrecuentes;
        public ICommand CommandSelectedItem { get; set; }
        public ICommand CommandBackTo { get; set; }

        private PreguntasFrecuente _ItemSelectedQuestion;
        private ApiService<PreguntasFrecuente, PreguntasFrecuente> apiService;
        public QuestionFrecuentlyViewModel(INavigation navigation)
        {
            NavigationService = navigation;
            Init();
            LoadQuestions();
        }
        private void Init()
        {
            CommandSelectedItem = new Command(ItemTapped);
            CommandBackTo = new Command(BackTo);
            apiService = new ApiService<PreguntasFrecuente, PreguntasFrecuente>();
        }

        private void BackTo()
        {
            NavigationService.PopAsync();
        }

        private void ItemTapped(object obj)
        {
            var sender = obj as QuestionFrecuentlyViewModel;

            var question = sender;
        }
        public ObservableCollection<PreguntasFrecuente> PreguntasFrecuentes
        {
            get => _PreguntasFrecuentes;
            set
            {
                _PreguntasFrecuentes = value;
                NotifyPropertyChanged();
            }
        }

        public PreguntasFrecuente ItemSelectedQuestion
        {
            get
            {
                return _ItemSelectedQuestion;
            }
            set
            {
                _ItemSelectedQuestion = value;

                if (value != null)
                {
                    bool visible = !value.DescripcionVisible;
                    _ItemSelectedQuestion.DescripcionVisible = visible;
                    _ItemSelectedQuestion.Icon = visible == false ? "\ue93d" : "\ue93b";
                }

                NotifyPropertyChanged();
                //_ItemSelectedQuestion = null;
            }
        }

        private async void LoadQuestions()
        {
            PreguntasFrecuentes = new ObservableCollection<PreguntasFrecuente>();
            //var questionsResult = await ExecuteBlocking(apiService.GetAll, Directions.DirectionsApi.PreguntasFrecuentes);
            if (Configuracion.preguntasFrecuentes != null)
                foreach (PreguntasFrecuente pregunta in Configuracion.preguntasFrecuentes)
                {
                    pregunta.Icon = "\ue93d";
                    PreguntasFrecuentes.Add(pregunta);
                }
        }
    }
}
