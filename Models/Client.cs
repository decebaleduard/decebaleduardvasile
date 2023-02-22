using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace decebaleduard.Models
{
    public class Client
    {
        public int ID { get; set; }

        public string Name { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Client name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Client name must be betwen 2 and 100 characters")]
        [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "Client name must be betwen 2 and 100 characters")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Client email is required")]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Client email must be between 2 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9-._@\s]+$", ErrorMessage = "Client email can contain only letters, space, -, _, . or @")]

        public string PhoneNr { get; set; }
        [Required(ErrorMessage = "Client phone number is required")]
        [Column(TypeName = "varchar(25)")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Client phone number must be between 5 and 25 characters")]
        [RegularExpression(@"^[0-9-+\s]+$", ErrorMessage = "Client phone number can contain only letters, space, - or +")]

        public decimal LastPurchase { get; set; }
        [Required(ErrorMessage = "Client's last purchase can contain only digits and .")]
        [Column(TypeName = "decimal(11, 2)")]
        [RegularExpression(@"^[0-9.]+$", ErrorMessage = "Client's last purchase can contain only digits and .")]
        public int StoreID { get; set; }
        public Store Store { get; set; }

    }
}