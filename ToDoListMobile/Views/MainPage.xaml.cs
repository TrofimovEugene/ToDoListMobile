using Newtonsoft.Json;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ToDoListMobile.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		public  ICommand ClickCommand { get; private set; }

		public MainPage()
		{
			InitializeComponent();
		}

		public class Request
		{
			public string Email { get; set; }
			public string Password { get; set; }
		}

		private async void LogInButton_ClickedAsync(object sender, System.EventArgs e)
		{
			var email = EmailEntry.Text;
			var password = PasswordEntry.Text;

			var requestMess = new Request()
			{
				Email = email,
				Password = password
			};

			var json = JsonConvert.SerializeObject(requestMess);

			var httpClient = new HttpClient();

			var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await httpClient.PostAsync(@"http://todolist.somee.com/api/Users/AutorizationUserAndGetToken", httpContent);
			var responseStr = await response.Content.ReadAsStringAsync();

		}
	}
}
