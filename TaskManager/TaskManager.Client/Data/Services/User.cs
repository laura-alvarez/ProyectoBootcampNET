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

        public async Task<IEnumerable<LoginDTO>> GetUserAsync()
        {
            var user = await _client.GetFromJsonAsync<IEnumerable<LoginDTO>>("User/GetAllUsers");

            return user;
    }
    }

    

}
