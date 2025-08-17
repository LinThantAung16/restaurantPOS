namespace RestaurantPOS.Database;
public class TblMainCategory
{
    public string maincategoryid { get; set; }
    public string maincategorycode { get; set; }
    public string maincategoryname { get; set; }
    public DateTime? createdat { get; set; }
    public string createdby { get; set; }
    public DateTime? modifiedat { get; set; }
    public string modifiedby { get; set; }
}