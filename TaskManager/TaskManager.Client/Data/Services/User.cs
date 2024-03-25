using System.Net.Http.Json;
using TaskManager.Client.Data.Dtos;

namespace TaskManager.Client.Data.Services
{
    public class User
    {
        private readonly HttpClient _client;

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

        public async Task<Boolean>? GetUserAsync(string param1, string param2)
        {
            string url = $"User/CheckUser?email={param1}&password={param2}";

            // Realiza la solicitud GET y espera la respuesta
            var user = await _client.GetFromJsonAsync<Boolean>(url);

            

            return user;
        }
    }

    

}
