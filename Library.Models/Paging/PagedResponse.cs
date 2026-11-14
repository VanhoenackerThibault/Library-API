namespace Library.Models.Paging
{
    public class PagedResponse<T>
    {
        public int TotalObjects { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public List<T> Result { get; set; } = [];
    }
}
