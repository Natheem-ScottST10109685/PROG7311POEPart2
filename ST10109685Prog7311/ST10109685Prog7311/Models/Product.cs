using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ST10109685Prog7311.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [MaxLength(100)]
        public string? ProductName { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        [MaxLength(100)]
        public string? Category { get; set; }

        public decimal? Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ProductionDate { get; set; }
    }
}