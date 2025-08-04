namespace DotnetPracticeCrud.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<BorrowModel> Borrows { get; set; }
        public ClientModel()
        {
            Borrows = new List<BorrowModel>();
        }
    }
}
