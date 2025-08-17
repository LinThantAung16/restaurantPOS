namespace RestaurantPOS.Database;
public class TblOrder
{
    public string orderid { get; set; }
    public string ordercode { get; set; }
    public string tablenumber { get; set; }
    public DateTime? createdat { get; set; }
    public string createdby { get; set; }
    public DateTime? closedat { get; set; }
    public string closedby { get; set; }
}