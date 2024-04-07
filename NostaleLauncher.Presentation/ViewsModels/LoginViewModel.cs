using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace NostaleLauncher.Presentation.ViewModels
{
    public class LoginViewModel
    {
        public event Action OnLoginSuccess;

        private readonly HttpClient _httpClient;
        public string Username { get; set; }
        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            _httpClient = CreateHttpClient();
            LoginCommand = new RelayCommand(async param => await LoginAsync(param));
        }

        private HttpClient CreateHttpClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://127.0.0.1:5058/")
            };
            // Configure the client if needed (headers, etc.)
            return client;
        }

        public async Task LoginAsync(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox?.Password;
            Debug.WriteLine("------------------------------------------------------- OZJODFJZFOJZOFJ-----------------------------------------");

                Debug.WriteLine("********************************** PASS  ********************************************** " + password);
                Debug.WriteLine("********************************** USERNAME  ********************************************** " + Username);

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(password))
            {

                return;
            }

            var loginInfo = new { Username, Password = password };
            var content = new StringContent(JsonSerializer.Serialize(loginInfo), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("user/login", content);
                if (response.IsSuccessStatusCode)
                {
                    OnLoginSuccess?.Invoke();
                }
                else
                {
                    Debug.WriteLine("********************************** RESPONSE  ********************************************** ", response);


                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("********************************** EXCEPTION  ********************************************** ", ex);   
            }
        }
    }
}