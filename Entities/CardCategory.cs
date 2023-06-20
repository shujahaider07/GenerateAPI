using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("CardCategory")]
    public class CardCategory
    {
        [Key]
        public int? Id { get; set; }
        public string? CardCategoryName { get; set; }
        public decimal? Cost { get; set; }
        public string? Plastic { get; set; }
        public string? Image { get; set; }

    }
 }
