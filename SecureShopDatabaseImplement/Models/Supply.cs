using MebelBusinessLogic.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SecureShopDatabaseImplement.Models
{
    public class Supply
    {
        public int Id { get; set; }
        [Required]
        public int MaterialId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public SupplyStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Module Module { get; set; }
    }
}
