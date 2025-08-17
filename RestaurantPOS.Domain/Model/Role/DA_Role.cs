using Microsoft.Extensions.Configuration.UserSecrets;
using RestaurantPOS.Database;
using RestaurantPOS.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
namespace RestaurantPOS.Domain.Model.Role
{
    public class DA_Role
    {
        private readonly AppDbContext _db;
        public DA_Role(AppDbContext db)
        {
            _db = db;
        }

        //get list of role
        public async Task<Result<roleResponseModel>> List()
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

        // create role
        public async Task<Result<roleResponseModel>> Create(roleRequestModel role)
        {
            try
            {
                var helper = new DevCode(_db);
                if (helper.Exists<TblRole>(r=>r.rolename ,role.roleName))
                {
                    return Result<roleResponseModel>.ValidationError("Role already exist.");
                }
                var newRole = new TblRole
                {
                    RoleId = Ulid.NewUlid().ToString(),
                    rolecode = helper.GetNextCode<TblRole>(r => r.rolecode, "R", 4),
                    rolename = role.roleName

                };
                _db.TblRoles.Add(newRole);
                await _db.SaveChangesAsync();
                return Result<roleResponseModel>.Success("Role created successfully.");
            }
            catch (Exception ex)
            {
                return Result<roleResponseModel>.SystemError(ex.Message);
            }
        }

        // Update role


    }
}
