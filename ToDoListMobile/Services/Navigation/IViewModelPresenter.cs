using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Core;
using ToDoListMobile.ViewModels;

namespace ToDoListMobile.Services.Navigation
{
    public interface IViewModelPresenter
    {
        Task<BaseViewModel> OpenViewModelAsync(Type viewModelType, CancellationToken ct, params Parameter[] parameters);

        Task<BaseViewModel> OpenViewModelAsync(Type viewModelType, CancellationToken ct, params object[] parameters);

        //Task<TResult> OpenViewModelAsync<TResult>(Type viewModelType, CancellationToken ct, params Parameter[] parameters);

        //Task<TResult> OpenViewModelAsync<TResult>(Type viewModelType, CancellationToken ct, params object[] parameters);

        Task CloseViewModelAsync(Type viewModelType, bool animate = true);

        Task NavigateToRootAsync();
    }
}