namespace RestaurantPOS.Database;
public class TblPayment
{
    public string paymentid { get; set; }
    public string orderid { get; set; }
    public decimal? totalamount { get; set; }
    public string paymentmethod { get; set; }
    public DateTime? paydate { get; set; }
    public string recivedby { get; set; }
}