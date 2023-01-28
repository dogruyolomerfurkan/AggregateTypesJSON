namespace WebAPI.Entities;

/// <summary>
/// Owned by User
/// </summary>
public class Order
{
    public string ProductName { get; set; }
    public int ProductAmount { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}
