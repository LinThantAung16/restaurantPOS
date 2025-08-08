namespace RestaurantPOS.Database;
public class TblItem
{
    public string ItemId { get; set; }
    public string ItemCode { get; set; }
    public string ItemName { get; set; }
    public string CategoryCode { get; set; }
    public decimal? Price { get; set; }
    public string Description { get; set; }
    public bool OutOfStock { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public string ModifiedBy { get; set; }
    public bool DeleteFlag { get; set; }
}