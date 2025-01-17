using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order.ApplicationCore.Entities;

public class OrderDetails
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    [Required]
    [Column(TypeName="varchar(50)")]
    public string ProductName { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    //FK
    public Orders Orders { get; set; }
}