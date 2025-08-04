namespace DotnetPracticeCrud.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public  bool Availability { get; set; }

        public BookModel()
        {
            
        }
    }
}
