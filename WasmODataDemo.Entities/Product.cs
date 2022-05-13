using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WasmODataDemo.Entities
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        public string MerchantName { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
    }
}