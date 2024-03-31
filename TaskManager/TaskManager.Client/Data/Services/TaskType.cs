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

        public async Task<List<TaskStateResponse>> GetTaskStateAsync()
        {

            var url = $"State/GetAllStates";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new List<TaskStateResponse>();

            var apiResponse = await response.Content.ReadAsStringAsync();

            return Generics.DeserializeJsonString<List<TaskStateResponse>>(apiResponse);
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

            var url = $"Task/GetAllTaskByUserId?userId="+userID;
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new List<TaskResponse>();

            var apiResponse = await response.Content.ReadAsStringAsync();

            return Generics.DeserializeJsonString<List<TaskResponse>>(apiResponse);
        }

        public async Task<String> UpdateTaskAsync(int Id, string taskName, string taskDescription, int userId, int categoryId, int stateId)
        {
            var task = new
            {
                taskName,
                taskDescription,
                userId,
                categoryId,
                stateId
            };

            string url = "Task/UpdateTask?idTask=" + Id;

            try
            {
                HttpResponseMessage response = await _client.PutAsJsonAsync(url, task);

                if (response.IsSuccessStatusCode)
                {

                    Console.WriteLine("Tarea actualizada exitosamente.");
                    return "ok";
                }
                else
                {
                    Console.WriteLine($"Error al actualizar la tarea: {response.StatusCode}");
                    return response.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud PUT: {ex.Message}");
                return ex.Message;
            }
        }


        public async Task<String> DeleteTaskAsync(int Id)
        {
            string url = "Task/DeleteTask?idTask=" + Id;

            try
            {
                StringContent emptyContent = new StringContent("");

                HttpResponseMessage response = await _client.PostAsync(url, emptyContent);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Tarea eliminada exitosamente.");
                    return "ok";
                }
                else
                {
                    Console.WriteLine($"Error al eliminar la tarea: {response.StatusCode}");
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
