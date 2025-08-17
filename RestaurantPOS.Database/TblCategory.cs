namespace RestaurantPOS.Database;
public class TblCategory
{
    public string categoryid { get; set; }
    public string categorycode { get; set; }
    public string categoryname { get; set; }
    public string maincategorycode { get; set; }
    public DateTime? createdat { get; set; }
    public string createdby { get; set; }
    public DateTime? modifiedat { get; set; }
    public string modifiedby { get; set; }
}