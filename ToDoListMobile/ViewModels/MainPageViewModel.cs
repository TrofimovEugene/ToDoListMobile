using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Input;
using ToDoListMobile.Views;
using Xamarin.Forms;

namespace ToDoListMobile.ViewModels
{
	public class MainPageViewModel : BaseViewModel
	{
		public ICommand LoginCommand { get; private set; }
		public ICommand RegistryCommand { get; private set; }
		public string Email { get; set; }
		public string Password { get; set; }
		
		public INavigation Navigation { get; set; }

		public MainPageViewModel()
		{
			RegistryCommand = new Command(OnRegistryButtonClick);
			LoginCommand = new Command(OnLoginButtonClick);
		}

		private async void OnLoginButtonClick()
		{
			var email = Email;
			var password = Password;

			var requestMess = new Request()
			{
				Email = email,
				Password = password
			};

			var json = JsonConvert.SerializeObject(requestMess);

			var httpClient = new HttpClient();

			var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await httpClient.PostAsync(@"http://todolist.somee.com/api/Users/AutorizationUserAndGetToken", httpContent);
			if (response.StatusCode != System.Net.HttpStatusCode.OK)
				return;
			var responseStr = await response.Content.ReadAsStringAsync();

			var user = JsonConvert.DeserializeObject<Response>(responseStr);

			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", user.AccessToken);
			response = await httpClient.GetAsync(@"http://todolist.somee.com/api/Users/" + user.IdUser);
			if (response.StatusCode != HttpStatusCode.OK) 
				return;
			var userModel = await response.Content.ReadAsStringAsync();
			Debug.WriteLine(userModel);
			await Navigation.PushAsync(page: new NotesListPage());
		}

		private class Request
		{
			public string Email { get; set; }
			public string Password { get; set; }
		}

		private class Response
		{
			[JsonProperty("accessToken")]
			public string AccessToken { get; set; }
			[JsonProperty("email")]
			public string Email { get; set; }
			[JsonProperty("idUser")]
			public int IdUser { get; set; }
		}

		private async void OnRegistryButtonClick()
		{
			
		}
	}
}
