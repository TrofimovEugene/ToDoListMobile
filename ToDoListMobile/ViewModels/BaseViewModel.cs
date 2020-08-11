using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ToDoListMobile.ViewModels
{
	public class BaseViewModel : NotifyPropertyChanged
	{
		public virtual Task InitializeAsync(CancellationToken ct)
		{
			return Task.FromResult(true);
		}

		public virtual Task InitializeAsync(CancellationToken ct, params object[] parameters)
		{
			return InitializeAsync(ct);
		}
	}
}
