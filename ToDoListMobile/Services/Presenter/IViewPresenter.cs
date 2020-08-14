using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDoListMobile.Services.Presenter
{
    public interface IViewPresenter
    {
        Task OpenViewAsync(Element view);

        Task CloseViewAsync(Type viewType, bool animate = true);

        Task NavigateToRootAsync();
    }
}