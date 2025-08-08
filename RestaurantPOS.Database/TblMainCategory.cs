namespace RestaurantPOS.Database;
public class TblMainCategory
{
    public string MainCategoryID { get; set; }
    public string MainCategoryCode { get; set; }
    public string MainCategoryName { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public string ModifiedBy { get; set; }
}