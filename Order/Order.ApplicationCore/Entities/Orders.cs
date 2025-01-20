using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order.ApplicationCore.Entities;

public class Orders
{
    public int Id { get; set; }
    [Required]
    [Column(TypeName="datetime2")]
    public DateTime OrderDate { get; set; }
    [Required]
    public int CustomerId { get; set; }
    [Required]
    [Column(TypeName="varchar(50)")]
    public string CustomerName { get; set; }
    public int PaymentMethodId { get; set; }
    [Required]
    [Column(TypeName="varchar(50)")]
    public string PaymentName { get; set; }
    [Required]
    [Column(TypeName="varchar(100)")]
    public string ShippingAddress { get; set; }
    [Required]
    [Column(TypeName="varchar(50)")]
    public string ShippingMethod { get; set; }
    public decimal BillAmount { get; set; }
    [Required]
    [Column(TypeName="varchar(50)")]
    public string OrderStatus { get; set; }

    public ICollection<OrderDetails> OrderDetails { get; set; }
    
}