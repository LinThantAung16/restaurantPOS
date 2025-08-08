using RestaurantPOS.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPOS.Domain.Model.Role
{
    public class BL_Role
    {
        private readonly DA_Role _daRole;
        public BL_Role(DA_Role daRole)
        {
            _daRole = daRole;
        }
        // Get roles
        public async Task<Result<roleResponseModel>> List()
        {
            return await _daRole.GetRolesAsync();
        }

    }
}
