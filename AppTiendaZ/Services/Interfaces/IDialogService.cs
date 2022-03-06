using AppTiendaZ.Views.Popup;
using Prism.Services;
using System;
using System.Threading.Tasks;

namespace AppTiendaZ.Services.Interfaces
{

    public interface IDialogServices
    {
        void ShowLoader();

        void HideLoader();

        Task<bool> DisplayAlertAsync(string title, string message, string acceptButton, string cancelButton);

        Task DisplayAlertAsync(string title, string message, string acceptButton);
    }

    public class DialogServices : IDialogServices
    {
        private readonly IPageDialogService _pageDialogService;

        public DialogServices()
        {
        }

        public DialogServices(IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;
        }

        public Task<bool> DisplayAlertAsync(string title, string message, string acceptButton, string cancelButton)
        {
            throw new NotImplementedException();
        }

        public async Task DisplayAlertAsync(string title, string message, string acceptButton)
        {
            var popup = new Views.Popup.MessagePopup(message);

            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);

        }

        public void HideLoader()
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        public void ShowLoader()
        {
            var pop = new Loading(true);

            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(pop);
        }
    }
}
