using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using ToDoListMobile.Services.Presenter;
using ToDoListMobile.ViewModels;
using Xamarin.Forms;

namespace ToDoListMobile.Services.Navigation
{
    public class ViewModelPresenter : IViewModelPresenter
    {
        private readonly IViewPresenter _viewPresenter;

        public ViewModelPresenter(IViewPresenter viewPresenter)
        {
            _viewPresenter = viewPresenter;
        }

        /*public async Task<TResult> OpenViewModelAsync<TResult>(Type viewModelType, CancellationToken ct, params Parameter[] parameters)
        {
            var viewModel = await OpenViewModelAsync(viewModelType, ct, parameters);
            if (viewModel is IResultPageViewModel<TResult> resultPageViewModel)
            {
                return await resultPageViewModel.ResultSource.GetResultAsync();
            }
            throw new InvalidOperationException("Result route mismatch");
        }

	    public async Task<TResult> OpenViewModelAsync<TResult>(Type viewModelType, CancellationToken ct, params object[] parameters)
	    {
		    var viewModel = await OpenViewModelAsync(viewModelType, ct, parameters);
		    if (viewModel is IResultPageViewModel<TResult> resultPageViewModel)
		    {
			    return await resultPageViewModel.ResultSource.GetResultAsync();
		    }
		    throw new InvalidOperationException("Result route mismatch");
	    }*/

        public async Task<BaseViewModel> OpenViewModelAsync(Type viewModelType, CancellationToken ct, params Parameter[] parameters)
        {
            var container = IoC.IoC.Container;

            // Resolve view model.
            var viewModel = (BaseViewModel) container.Resolve(viewModelType);

            // Resolve view for view model.
            var view = container.ResolveKeyed<Element>(viewModelType);

            view.BindingContext = viewModel;
            await Task.WhenAny(_viewPresenter.OpenViewAsync(view), viewModel.InitializeAsync(ct));

            return viewModel;
        }

	    public async Task<BaseViewModel> OpenViewModelAsync(Type viewModelType, CancellationToken ct, params object[] parameters)
	    {
		    var container = IoC.IoC.Container;

		    // Resolve view model.
		    var viewModel = (BaseViewModel) container.Resolve(viewModelType);

		    // Resolve view for view model.
		    var view = container.ResolveKeyed<Element>(viewModelType);

		    view.BindingContext = viewModel;
		    await Task.WhenAny(_viewPresenter.OpenViewAsync(view), viewModel.InitializeAsync(ct));

		    return viewModel;
	    }

		public Task CloseViewModelAsync(Type viewModelType, bool animate = true)
        {
            var container = IoC.IoC.Container;

            var registration = container.ComponentRegistry.Registrations
                .FirstOrDefault(r => r.Services.OfType<KeyedService>()
                    .Any(s => Equals(s.ServiceKey, viewModelType)));
            if (registration != null)
            {
                var viewType = registration.Activator.LimitType;
                Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                {
                   await _viewPresenter.CloseViewAsync(viewType, animate);
                });
            }
            return Task.FromResult(true);
        }

	    public async Task NavigateToRootAsync()
	    {
		    await _viewPresenter.NavigateToRootAsync();
	    }
    }
}