namespace TaskManager.Client.Extensiones
{
    using Blazored.LocalStorage;

    public class LocalStorage
    {
        private readonly ILocalStorageService _localStorage;

        public LocalStorage(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task SignInAsync(string key, string value)
        {
            await _localStorage.SetItemAsync(key, value);
        }

        public async Task<string> GetUserIdAsync(string key)
        {
            return await _localStorage.GetItemAsync<string>(key);
        }

        public async Task RemoveItemAsync(string key)
        {
            await _localStorage.RemoveItemAsync(key);
        }
    }

}
