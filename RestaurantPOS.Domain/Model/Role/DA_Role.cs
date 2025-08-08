using RestaurantPOS.Database;
using RestaurantPOS.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPOS.Domain.Model.Role
{
    public class DA_Role
    {
        private readonly AppDbContext _db;
        public DA_Role(AppDbContext db)
        {
            _db = db;
        }

        //get role
        public async Task<Result<roleResponseModel>> GetRolesAsync()
        {
            var model = new roleResponseModel();
            try
            {
                var data = await _db.TblRoles
                                    .OrderByDescending(x => x.RoleId)
                                    .ToListAsync();
                if (data is null)
                {
                    return Result<roleResponseModel>.NotFoundError("Role Not Found.");
                }

                model.roles = data.Select(roleListModel.FromTblRole).ToList();
                return Result<roleResponseModel>.Success(model);
            }
            catch (Exception ex)
            {
                return Result<roleResponseModel>.SystemError(ex.Message);
            }
        }
    }
}
