using AppTiendaZ.Models;
using AppTiendaZ.Services;
using AppTiendaZ.Services.Interfaces;
using AppTiendaZ.ViewModels.Notificaciones;
using AppTiendaZ.Views.Popup;
using BilleteraPais.Views.Popup;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace AppTiendaZ.ViewModels
{
    /// <summary>
    /// This viewmodel extends in another viewmodels.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public INavigation NavigationService { get; set; }
        protected IDialogServices DialogService { get; }

        private Configuracion _Configuracion;

        protected static ObservableCollection<PlanDePago> Cuotas { get; set; }

        //protected IApiService<LoginModel> ServiceLogin { get; set; }
        public Credito Credito
        {
            get
            {
                return new ServiceLocal<Credito>().GetDataSettings(Directions.DirectionsApi.UserData);
            }
            set
            {
                new ServiceLocal<Credito>().SaveDataSettings(Directions.DirectionsApi.UserData, value);
            }
        }
        protected Configuracion Configuracion
        {
            get => new ServiceLocal<Configuracion>().GetDataSettings(Directions.DirectionsApi.Configuraciones);
            set
            {
                new ServiceLocal<Configuracion>().SaveDataSettings(Directions.DirectionsApi.Configuraciones, value);
            }
        }

        public BaseViewModel()
        {
            if (Cuotas == null)
            {
                Cuotas = new ObservableCollection<PlanDePago>();
            }
            if (Configuracion == null)
            {
                Configuracion = new Configuracion();
            }
            DialogService = new DialogServices();
        }

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected async Task<bool> Load(Func<Task> loadFunc, bool blocking, bool silent)
        {
            bool isEmpty = false;

            try
            {
                var task = loadFunc();

                if (task.IsCompleted)
                {
                    isEmpty = true;
                    return true;
                }

                if (blocking)
                {
                    this.DialogService.ShowLoader();
                }

                await task;

                return true;
            }
            catch (Exception ex)
            {
                if (!silent)
                {
                    DialogService.DisplayAlertAsync("Error!", "Algo ha sucedido en el proceso, vuelve a intentar", "Ok").Wait(1000);
                }

                return false;
            }
            finally
            {
                if (!isEmpty && blocking)
                {
                    DialogService.HideLoader();
                }
            }
        }

        protected async Task<bool> ExecuteBlocking(Func<Task> func, string title = null, string message = null, string okButton = null)
        {
            var task = func();

            if (task.IsCompleted)
            {
                if (task.IsFaulted)
                {
                    if (task.Exception?.InnerException is CommunicationException comm)
                    {
                        message = comm.Message;

                        var act = new PopupMessage("Error", message);

                        await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(act);
                    }

                    //DialogServices.DisplayAlertAsync(title ?? DefaultErrorTitle, message ?? DefaultErrorMessage, okButton ?? DefaultErrorOkButton).Forget();

                    return false;
                }

                return true;
            }

            try
            {
                DialogService.ShowLoader();

                await task;

                return true;
            }
            catch (Exception ex)
            {
                if (ex is CommunicationException comm)
                {
                    message = comm.Message;
                    var act = new PopupMessage("Error", message);

                    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(act);
                }

                //DialogServices.DisplayAlertAsync(title ?? DefaultErrorTitle, message ?? DefaultErrorMessage, okButton ?? DefaultErrorOkButton).Forget();

                return false;
            }
            finally
            {
                DialogService.HideLoader();
            }
        }

        protected Task<bool> ExecuteBlocking<TParam>(Func<TParam, Task> func, TParam p, string title = null, string message = null, string okButton = null)
        {
            return ExecuteBlocking(() => func(p), title, message, okButton);
        }

        protected Task<bool> ExecuteBlocking<TParam1, TParam2>(Func<TParam1, TParam2, Task> func, TParam1 p1, TParam2 p2, string title = null, string message = null, string okButton = null)
        {
            return ExecuteBlocking(() => func(p1, p2), title, message, okButton);
        }

        protected Task<bool> ExecuteBlocking<TParam1, TParam2, TParam3>(Func<TParam1, TParam2, TParam3, Task> func, TParam1 p1, TParam2 p2, TParam3 p3, string title = null, string message = null, string okButton = null)
        {
            return ExecuteBlocking(() => func(p1, p2, p3), title, message, okButton);
        }

        protected Task<bool> ExecuteBlocking<TParam1, TParam2, TParam3, TParam4>(Func<TParam1, TParam2, TParam3, TParam4, Task> func, TParam1 p1, TParam2 p2, TParam3 p3, TParam4 p4, string title = null, string message = null, string okButton = null)
        {
            return ExecuteBlocking(() => func(p1, p2, p3, p4), title, message, okButton);
        }

        protected Task<bool> ExecuteBlocking<TParam1, TParam2, TParam3, TParam4, TParam5>(Func<TParam1, TParam2, TParam3, TParam4, TParam5, Task> func, TParam1 p1, TParam2 p2, TParam3 p3, TParam4 p4, TParam5 p5, string title = null, string message = null, string okButton = null)
        {
            return ExecuteBlocking(() => func(p1, p2, p3, p4, p5), title, message, okButton);
        }

        protected async Task<AsyncResult<TResult>> ExecuteBlocking<TResult>(Func<Task<TResult>> func, string title = null, string message = null, string okButton = null, bool silent = false)
        {
            var task = func();

            if (task.IsCompleted)
            {
                if (task.IsFaulted)
                {
                    if (task.Exception?.InnerException is CommunicationException comm)
                    {
                        message = comm.Message;
                        var act = new PopupMessage("Error", message);

                        await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();

                        await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(act);
                    }

                    return AsyncResult<TResult>.Fail();
                }

                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();

                return AsyncResult<TResult>.Ok(task.Result);
            }

            try
            {
                if (!silent)
                {
                    var act = new Loading();

                    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(act);
                }

                var result = await task;

                if (!silent)
                    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();

                return AsyncResult<TResult>.Ok(result);
            }
            catch (CommunicationException ex)
            {
                var act = new PopupMessage("Error", ex.Message);

                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();

                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(act);

                return AsyncResult<TResult>.Fail();
            }
            catch (Exception ex)
            {
                if (ex is CommunicationException comm)
                {
                    message = comm.Message;
                    var act = new PopupMessage("Error", message);

                    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();

                    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(act);
                }

                return AsyncResult<TResult>.Fail();
            }
        }

        protected Task<AsyncResult<TResult>> ExecuteBlocking<TParam, TResult>(Func<TParam, Task<TResult>> func, TParam p1, string title = null, string message = null, string okButton = null, bool silent = false)
        {
            return this.ExecuteBlocking(() => func(p1), title, message, okButton, silent);
        }

        protected Task<AsyncResult<TResult>> ExecuteBlocking<TParam1, TParam2, TResult>(Func<TParam1, TParam2, Task<TResult>> func, TParam1 p1, TParam2 p2, string title = null, string message = null, string okButton = null)
        {
            return ExecuteBlocking(() => func(p1, p2), title, message, okButton);
        }

        protected Task<AsyncResult<TResult>> ExecuteBlocking<TParam1, TParam2, TParam3, TResult>(Func<TParam1, TParam2, TParam3, Task<TResult>> func, TParam1 p1, TParam2 p2, TParam3 p3, string title = null, string message = null, string okButton = null)
        {
            return ExecuteBlocking(() => func(p1, p2, p3), title, message, okButton);
        }

        protected Task<AsyncResult<TResult>> ExecuteBlocking<TParam1, TParam2, TParam3, TParam4, TResult>(Func<TParam1, TParam2, TParam3, TParam4, Task<TResult>> func, TParam1 p1, TParam2 p2, TParam3 p3, TParam4 p4, string title = null, string message = null, string okButton = null)
        {
            return ExecuteBlocking(() => func(p1, p2, p3, p4), title, message, okButton);
        }

        protected class AsyncResult<TResult>
        {
            public TResult Result
            {
                get; private set;
            }

            public bool Succeeded { get; private set; }

            public static AsyncResult<TResult> Fail()
            {
                return new AsyncResult<TResult>
                {
                    Succeeded = false
                };
            }

            public static AsyncResult<TResult> Ok(TResult result)
            {
                return new AsyncResult<TResult>
                {
                    Result = result,
                    Succeeded = true
                };
            }

            internal Task<ObservableCollection<Notificacion>> ToList()
            {
                throw new NotImplementedException();
            }
        }
    }
}
