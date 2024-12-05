
using System.ComponentModel.DataAnnotations;


namespace Application.Models.Request
{
    public class ProductUpdateRequest
    {
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}
