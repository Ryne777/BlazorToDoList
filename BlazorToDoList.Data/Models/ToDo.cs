namespace BlazorToDoList.Data.Models
{
    public class ToDo:ModelBase
    {
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
