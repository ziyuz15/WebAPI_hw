namespace Order.ApplicationCore.Model.ResponseModel;

public class OrderDetailsResponseModel
{
    public int Id { get; set; }
    public int OrdersId { get; set; } //FK
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}