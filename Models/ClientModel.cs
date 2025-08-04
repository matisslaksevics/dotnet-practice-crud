namespace DotnetPracticeCrud.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasActiveBook { get; set; }

        public ClientModel()
        {
            
        }
    }
}
