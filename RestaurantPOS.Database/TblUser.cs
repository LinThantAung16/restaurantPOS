namespace RestaurantPOS.Database;
public class TblUser
{
    public string userid { get; set; }
    public string username { get; set; }
    public string rolecode { get; set; }
    public string password { get; set; }

    public TblRole Role { get; set; }
}