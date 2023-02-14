namespace BookStoreApi.Models.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorSurname { get; set; } = string.Empty;
        public DateTime AuthorBirthday { get; set; }
    }
}
