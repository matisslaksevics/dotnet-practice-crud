namespace DotnetPracticeCrud.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string BookName { get; set; }

        public ICollection<BorrowModel> Borrows { get; set; }
        public BookModel()
        {
            Borrows = new List<BorrowModel>();
        }
    }
}
