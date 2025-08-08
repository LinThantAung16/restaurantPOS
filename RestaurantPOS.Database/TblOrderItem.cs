namespace RestaurantPOS.Database;
public class TblOrderItem
{
    public string OrderItemID { get; set; }
    public string OrderID { get; set; }
    public string ItemCode { get; set; }
    public int? Qty { get; set; }
    public decimal? TotalPrice { get; set; }
}