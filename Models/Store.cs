using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Specialized;

namespace decebaleduard.Models
{
    public class Store
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "Store name is required")]
        [Column(TypeName = "varchar(100")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Store name must be between 2 and 100 Characters")]
        [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "Store name can contain only letters, space and -")]

        public string City { get; set; }
        [Required(ErrorMessage = "City name is required")]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "City name must be between 2 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage= "Store city can contain only letters, space and -")]

        public string Adress { get; set; }
        [Required(ErrorMessage = "Store adress is requred")]
        [Column(TypeName = "varchar(200)")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Adress must be between 5 and 200 characters")]
        [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "Store adress can contain only letters, digits, space and -")]

        public ICollection<Store> Stores { get; set; }

    }
}