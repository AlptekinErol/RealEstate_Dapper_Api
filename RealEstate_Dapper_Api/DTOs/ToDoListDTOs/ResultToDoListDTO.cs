namespace RealEstate_Dapper_Api.DTOs.ToDoListDTOs
{
    public class ResultToDoListDTO
    {
        public int ToDoListId { get; set; }
        public string? Description { get; set; }
        public bool ToDoListStatus{ get; set; }
    }
}
