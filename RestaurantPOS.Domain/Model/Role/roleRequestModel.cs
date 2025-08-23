using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPOS.Domain.Model.Role
{
    public class roleCreateRequestModel
    {
        public string roleName { get; set; }
    }

    public class roleUpdateRequestModel
    {
        public string roleCode { get; set; }
        public string roleName { get; set; }
    }

    public class roleDeleteRequestModel
    {
        public string roleCode { get; set; }
    }
}
