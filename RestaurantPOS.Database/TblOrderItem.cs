namespace RestaurantPOS.Database;
public class TblOrderItem
{
    public string orderitemid { get; set; }
    public string orderid { get; set; }
    public string itemcode { get; set; }
    public int? qty { get; set; }
    public decimal? totalprice { get; set; }
}