using Blazored.LocalStorage;
using Intuit.Ipp.Core.Configuration;
using Intuit.Ipp.Data;
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

        public async Task<LoginResponse> CheckUserAsync(string param1, string param2)
        {
            
            var url = $"User/CheckUser?email={param1}&password={param2}";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new LoginResponse(false, null!, "Error occured. Try again later...");

            var apiResponse = await response.Content.ReadAsStringAsync();
            
            return Generics.DeserializeJsonString<LoginResponse>(apiResponse);
        }

        public async Task<UserResponse> GetUserAsync(string userID)
        {

            var url = $"User/GetUser?idUser={userID}";
            var response = await _client.GetAsync(url);

            
            if (!response.IsSuccessStatusCode)
                return new UserResponse(0, "", "", "", "");

            var apiResponse = await response.Content.ReadAsStringAsync();

            return Generics.DeserializeJsonString<UserResponse>(apiResponse);
        }


        public async Task<String> CreateUserAsync(string name, string lastName, string email, string password)
        {
            var user = new
            {
                name,
                lastName,
                email,
                password
            };

            string url = "User/AddUser";

            try
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync(url, user);

                if (response.IsSuccessStatusCode)
                {

                    Console.WriteLine("Usuario creado exitosamente.");
                    return "ok";
                }
                else
                {
                    Console.WriteLine($"Error al crear usuario: {response.StatusCode}");
                    return response.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud POST: {ex.Message}");
                return ex.Message;
            }
        }


        public async Task<String> UpdateUserAsync(string name, string lastName, string email, string password, string userID)
        {
            var user = new
            {
                name,
                lastName,
                email,
                password
            };

            string url = $"User/UpdateUser?idUser={userID}";;

            try
            {
                HttpResponseMessage response = await _client.PutAsJsonAsync(url, user);

                if (response.IsSuccessStatusCode)
                {

                    Console.WriteLine("Usuario actualizado exitosamente.");
                    return "ok";
                }
                else
                {
                    Console.WriteLine($"Error al actualizar usuario: {response.StatusCode}");
                    return response.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud POST: {ex.Message}");
                return ex.Message;
            }
        }
    }



}
