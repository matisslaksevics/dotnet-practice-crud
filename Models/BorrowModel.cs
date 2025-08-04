using System.ComponentModel.DataAnnotations;

namespace DotnetPracticeCrud.Models
{
    public class BorrowModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public ClientModel Client { get; set; }
        public int BookId { get; set; }
        public BookModel Book { get; set; }
        [Required(ErrorMessage = "Borrow date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BorrowDate { get; set; }

        public BorrowModel()
        {
            
        }
    }
}
