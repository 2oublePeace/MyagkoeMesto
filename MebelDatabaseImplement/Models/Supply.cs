using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MebelDatabaseImplement.Models
{
    public class Supply
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("SupplyId")]
        public virtual List<SupplyMaterial> SupplyMaterials { get; set; }
    }
}
