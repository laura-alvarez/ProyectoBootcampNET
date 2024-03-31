namespace TaskManager.Client.Data.Dtos
{
    public class ServiceResponses
    {
        public record class GeneralResponse(bool Flag, string Message);
        public record class LoginResponse(bool Flag, string Token, string Message);
        public record class TaskTypeResponse(int Id, string Category, bool IsDelete);
        public record class TaskStateResponse(int Id, string State, bool IsDelete);
        public record class TaskResponse(int Id, string TaskName, string TaskDescription, int CategoryID,int StateID);

    }
}
