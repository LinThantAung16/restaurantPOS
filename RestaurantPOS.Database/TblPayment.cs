namespace RestaurantPOS.Database;
public class TblPayment
{
    public string PaymentID { get; set; }
    public string OrderID { get; set; }
    public decimal? TotalAmount { get; set; }
    public string PaymentMethod { get; set; }
    public DateTime? PayDate { get; set; }
    public string RecivedBy { get; set; }
}