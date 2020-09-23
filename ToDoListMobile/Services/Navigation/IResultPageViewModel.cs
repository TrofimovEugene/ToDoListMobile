namespace ToDoListMobile.Services.Navigation
{
    public interface IResultPageViewModel<TResult>
    {
        AsyncResultSource<TResult> ResultSource { get; }
    }
}