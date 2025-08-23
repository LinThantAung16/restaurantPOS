using RestaurantPOS.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPOS.Domain.Model.Role
{
    public class roleResponseModel
    {
        public roleListModel role { get; set; } //to get single role for edit
        public List<roleListModel> roles { get; set; } //to get list of roles
    }
    public class roleListModel
    {
        public string roleId { get; set; }
        public string roleCode { get; set; }
        public string roleName { get; set; } 
        public static roleListModel FromTblRole(TblRole role)
        {
            return new roleListModel
            {
                roleId = role.RoleId,
                roleCode = role.rolecode,
                roleName = role.rolename
            };
        }
    }   
}
