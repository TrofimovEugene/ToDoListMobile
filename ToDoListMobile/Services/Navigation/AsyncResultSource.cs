using System.Threading.Tasks;

namespace ToDoListMobile.Services.Navigation
{
    public class AsyncResultSource<TResult>
    {
        private readonly TaskCompletionSource<TResult> _tcs;

        public AsyncResultSource()
        {
            _tcs = new TaskCompletionSource<TResult>();
            ReturnDefaultIfCancel = true;
        }

        public bool ReturnDefaultIfCancel { get; set; }

        public Task<TResult> GetResultAsync()
        {
            return _tcs.Task;
        }

        public void SetResult(TResult result)
        {
            _tcs.TrySetResult(result);
        }

        public void SetCanceled()
        {
            if (ReturnDefaultIfCancel)
            {
                _tcs.TrySetResult(default(TResult));
            }
            else
            {
                _tcs.TrySetCanceled();
            }
        }
    }
}