namespace BlazorToDoList.Bl.ViewModels
{
    public record IndexToDoViewModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
