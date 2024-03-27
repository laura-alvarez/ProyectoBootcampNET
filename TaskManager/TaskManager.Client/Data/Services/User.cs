using Blazored.LocalStorage;
using Intuit.Ipp.Core.Configuration;
using SharedClassLibrary.GenericModels;
using System.Net.Http;
using System.Net.Http.Json;
using TaskManager.Client.Data.Dtos;
using static TaskManager.Client.Data.Dtos.ServiceResponses;

namespace TaskManager.Client.Data.Services
{
    public class User
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "api/Account";
       // private readonly ILocalStorageService localStorageService;

        public User(HttpClient client) {
            _client = client;
        }

        public async Task<IEnumerable<LoginDTO>> GetUserAsync2(string param1, string param2)
        {
            string url = $"User/GetAllUsers?param1={param1}&param2={param2}";

            // Realiza la solicitud GET y espera la respuesta
            var user = await _client.GetFromJsonAsync<IEnumerable<LoginDTO>>(url);

           // var user = await _client.GetFromJsonAsync<IEnumerable<LoginDTO>>("User/GetAllUsers");

            return user;
        }

        public async Task<LoginModel> GetUserAsync(string param1, string param2)
        {
            string url = $"User/CheckUser?email={param1}&password={param2}";

            // Realiza la solicitud GET y espera la respuesta
            var user = await _client.GetFromJsonAsync<LoginModel>(url);

            

            return user;
        }


        public async Task<LoginResponse> GetUserAsync3(string param1, string param2)
        {
            
            var url = $"User/CheckUser?email={param1}&password={param2}";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new LoginResponse(false, null!, "Error occured. Try again later...");

            var apiResponse = await response.Content.ReadAsStringAsync();
            
            return Generics.DeserializeJsonString<LoginResponse>(apiResponse);
        }

    }



}
