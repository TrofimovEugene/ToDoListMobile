using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using ToDoListMobile.Models;
using Xamarin.Forms;

namespace ToDoListMobile.Services.Presenter
{
    public class ViewPresenter : IViewPresenter
    {
        private readonly INavigation _navigation;
	    private readonly IPopupNavigation _popupNavigation;
        private readonly IDictionary<Type, PresentationType> _viewPresentationTypes;

        public ViewPresenter(INavigation navigation,
	        IPopupNavigation popupNavigation,
	        IDictionary<Type, PresentationType> viewPresentationTypes)
        {
            _navigation = navigation;
	        _popupNavigation = popupNavigation;
            _viewPresentationTypes = viewPresentationTypes;
        }


        static readonly object OpenViewLocker = new object();

        public Task OpenViewAsync(Element view)
        {
	        if (!_viewPresentationTypes.TryGetValue(view.GetType(), out PresentationType presentationType))
		        return Task.FromResult(true);

	        if (!(view is Page page)) 
		        return Task.FromResult(true);

	        var viewType = view.GetType();

	        // + блокировка добавления представления в стек навигации, если представление уже есть в стеке
	        lock (OpenViewLocker)
	        {
		        Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
		        {
			        switch (presentationType)
			        {
				        case PresentationType.Default:
					        if (_navigation.NavigationStack.Count > 0 
					            && _navigation.NavigationStack[_navigation.NavigationStack.Count - 1].GetType() == viewType)
					        {
						        return;
					        }
					        await _navigation.PushAsync(page);
					        break;
				        case PresentationType.Modal:
					        if (_navigation.ModalStack.Count > 0
					            && _navigation.ModalStack[_navigation.ModalStack.Count - 1].GetType() == viewType)
					        {
						        return;
					        }
					        await _navigation.PushModalAsync(page);
					        break;
				        case PresentationType.Popup:
					        var stack = _popupNavigation.PopupStack;
					        if (stack.Count > 0 && stack[stack.Count - 1].GetType() == viewType)
					        {
						        return;
					        }
					        await _navigation.PushPopupAsync(page as PopupPage);
					        break;
				        case PresentationType.None:
				        case PresentationType.Custom:
					        break;
				        default:
					        throw new ArgumentOutOfRangeException();
			        }
		        });
		        return Task.FromResult(true);
	        }
        }

	    static readonly object CloseViewLocker = new object();

        public Task CloseViewAsync(Type viewType, bool animate = true)
        {
	        if (!_viewPresentationTypes.TryGetValue(viewType, out PresentationType presentationType))
		        return Task.FromResult(true);
			// + проверка наличия нужного представления перед выталкиванием из стека

	        lock (CloseViewLocker)
	        {
		        Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
		        {
			        switch (presentationType)
			        {
				        case PresentationType.Default:
					        if (_navigation.NavigationStack.Count == 0)
						        return;
					        if (_navigation.NavigationStack[_navigation.NavigationStack.Count - 1].GetType() != viewType)
					        {
						        return;
					        }
					        await _navigation.PopAsync();
					        break;
				        case PresentationType.Modal:
					        if (_navigation.ModalStack.Count == 0)
						        return;
					        if (_navigation.ModalStack[_navigation.ModalStack.Count - 1].GetType() != viewType)
					        {
						        return;
					        }
					        await _navigation.PopModalAsync();
					        break;
						case PresentationType.Popup:
					        var stack = _popupNavigation.PopupStack;
					        if (stack.Count == 0)
						        return;
					        if (stack[stack.Count - 1].GetType() != viewType)
					        {
						        return;
					        }
					        await _navigation.PopPopupAsync(animate);
					        break;
						case PresentationType.None:
				        case PresentationType.Custom:
					        throw new ArgumentOutOfRangeException();
				        default:
					        throw new ArgumentOutOfRangeException();
			        }
				});
		        return Task.FromResult(true);
			}
        }

        public async Task NavigateToRootAsync()
	    {
		    await _navigation.PopToRootAsync();
	    }
    }
}