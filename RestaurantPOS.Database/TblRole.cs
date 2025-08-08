namespace RestaurantPOS.Database;
public class TblRole
{
    public string RoleId { get; set; }
    public string rolecode { get; set; }
    public string rolename { get; set; }

    public ICollection<TblUser> Users { get; set; }
}