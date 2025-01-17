using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Model.RequestModel;

public class OrderRequestModel
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public int PaymentMethodId { get; set; }
    public string PaymentName { get; set; }
    public string ShippingAddress { get; set; }
    public string ShippingMethod { get; set; }
    public decimal BillAmount { get; set; }
    public string OrderStatus { get; set; }
    //FK
    public ICollection<OrderDetailsRequestModel> OrderDetails { get; set; }
}