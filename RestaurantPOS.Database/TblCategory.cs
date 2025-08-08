namespace RestaurantPOS.Database;
public class TblCategory
{
    public string CategoryID { get; set; }
    public string CategoryCode { get; set; }
    public string CategoryName { get; set; }
    public string MainCategoryCode { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public string ModifiedBy { get; set; }
}