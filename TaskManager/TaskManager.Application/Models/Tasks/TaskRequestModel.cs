namespace TaskManager.Application.Models.Users
{
    public class TaskRequestModel
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public int StateId { get; set; }

    }
}
