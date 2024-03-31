using Blazored.LocalStorage;
using Intuit.Ipp.Core.Configuration;
using Intuit.Ipp.Data;
using SharedClassLibrary.GenericModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using TaskManager.Client.Data.Dtos;
using static TaskManager.Client.Data.Dtos.ServiceResponses;

namespace TaskManager.Client.Data.Services
{
    public class TaskType
    {
        private readonly HttpClient _client;
       
       // private readonly ILocalStorageService localStorageService;

        public TaskType(HttpClient client) {
            _client = client;
        }

        public async Task<List<TaskTypeResponse>> GetTaskTypeAsync()
        {
            
            var url = $"Category/GetAllCategories";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new List<TaskTypeResponse>();

            var apiResponse = await response.Content.ReadAsStringAsync();
            
            return Generics.DeserializeJsonString<List<TaskTypeResponse>> (apiResponse);
        }


        public async Task<String> CreateTaskAsync(string taskName, string taskDescription, int userId, int categoryId, int stateId)
        {
            var task = new
            {
                taskName,
                taskDescription,
                userId,
                categoryId,
                stateId

            };

            string url = "Task/AddTask";

            try
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync(url, task);

                if (response.IsSuccessStatusCode)
                {

                    Console.WriteLine("Tarea creada exitosamente.");
                    return "ok";
                }
                else
                {
                    Console.WriteLine($"Error al crear la tarea: {response.StatusCode}");
                    return response.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud POST: {ex.Message}");
                return ex.Message;
            }
        }


        public async Task<List<TaskResponse>> GetAllTaskByUserID(string userID)
        {

            var url = $"Task/GetAllTaskByUserId?userId=1003";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new List<TaskResponse>();

            var apiResponse = await response.Content.ReadAsStringAsync();

            return Generics.DeserializeJsonString<List<TaskResponse>>(apiResponse);
        }
    }



}
