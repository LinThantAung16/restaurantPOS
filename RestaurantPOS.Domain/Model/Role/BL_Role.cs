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
            return await _daRole.List();
        }
        //Get role by code
        public async Task<Result<roleResponseModel>> Edit(string roleCode)
        {
            try
            {
                if (roleCode == null)
                {
                    return Result<roleResponseModel>.ValidationError("Role code not found");
                }

                return await _daRole.Edit(roleCode);
            }
            catch (Exception ex) {
                return Result<roleResponseModel>.SystemError(ex.Message);
            }
            
        }

        //create role
        public async Task<Result<roleResponseModel>> Create(roleCreateRequestModel req)
        {
            try
            {
                // Logic to insert the role into the database
                if (req == null || req.roleName=="")
                {
                    return Result<roleResponseModel>.ValidationError("Role cannot be null or empty.");
                }

                    return  await _daRole.Create(req);
                  
            }
            catch (Exception ex)
            {
                return Result<roleResponseModel>.SystemError(ex.Message);
            }
        }

        //update role
        public async Task<Result<roleResponseModel>> Update(roleUpdateRequestModel req)
        {
            try
            {
                // Logic to insert the role into the database
                if (req == null || req.roleName == "")
                {
                    return Result<roleResponseModel>.ValidationError("Role cannot be null or empty.");
                }
                return await _daRole.Update(req);
            }
            catch (Exception ex)
            {
                return Result<roleResponseModel>.SystemError(ex.Message);
            }
        }

        //delete role
        public async Task<Result<roleResponseModel>> Delete(string roleCode)
        {
            try
            {
                if (roleCode == null)
                {
                    return Result<roleResponseModel>.ValidationError("Role code not found");
                }
                return await _daRole.Delete(roleCode);
            }
            catch (Exception ex)
            {
                return Result<roleResponseModel>.SystemError(ex.Message);
            }
        }
    }
}
