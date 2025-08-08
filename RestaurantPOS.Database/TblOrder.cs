namespace RestaurantPOS.Database;
public class TblOrder
{
    public string OrderID { get; set; }
    public string OrderCode { get; set; }
    public string TableNumber { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? ClosedAt { get; set; }
    public string ClosedBy { get; set; }
}