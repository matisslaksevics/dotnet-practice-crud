namespace DotnetPracticeCrud.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasBook { get; set; }
        public int? bookId { get; set; }
        public BookModel Book { get; set; }
        public DateTime BorrowDate { get; set; } = DateTime.Now;
        public ClientModel()
        {
            
        }
    }
}
