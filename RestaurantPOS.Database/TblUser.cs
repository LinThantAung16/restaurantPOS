namespace RestaurantPOS.Database;
public class TblUser
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string RoleCode { get; set; }
    public string Password { get; set; }

    public TblRole Role { get; set; }
}