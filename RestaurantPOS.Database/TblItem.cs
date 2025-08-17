namespace RestaurantPOS.Database;
public class TblItem
{
    public string itemid { get; set; }
    public string itemcode { get; set; }
    public string itemname { get; set; }
    public string categorycode { get; set; }
    public decimal? price { get; set; }
    public string description { get; set; }
    public bool outofstock { get; set; }
    public DateTime? createdat { get; set; }
    public string createdby { get; set; }
    public DateTime? modiifiedat { get; set; }
    public string modifiedby { get; set; }
    public bool deleteflag { get; set; }
}