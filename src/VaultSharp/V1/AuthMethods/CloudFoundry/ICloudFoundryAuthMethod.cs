using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VaultSharp.V1.AuthMethods.CloudFoundry.Models;
using VaultSharp.V1.Commons;

namespace VaultSharp.V1.AuthMethods.CloudFoundry
{
    public interface ICloudFoundryAuthMethod
    {
        /// <summary>
        /// Create a role in Vault granting a particular level of access to a particular group of CF instances.
        /// We recommend using the CF API or the CF CLI to gain the IDs you wish to target.
        /// </summary>
        /// <param name="role">The name of the role</param>
        /// <param name="request">The role parameters</param>
        /// <param name="mountPoint"></param>
        /// <returns>Info about the created role</returns>
        Task CreateRoleAsync(string role, RoleInfo request, string mountPoint = AuthMethodDefaultPaths.CloudFoundry);

        /// <summary>
        /// Returns a CF role.
        /// </summary>
        /// <param name="role">The name of the role</param>
        /// <param name="mountPoint"></param>
        /// <returns>Information about the role</returns>
        Task<Secret<RoleInfo>> GetRoleAsync(string role, string mountPoint = AuthMethodDefaultPaths.CloudFoundry);

        /// <summary>
        /// Returns registered CF roles.
        /// </summary>
        /// <param name="mountPoint"></param>
        /// <returns>A list of roles</returns>
        Task<Secret<RoleList>> ListRolesAsync(string mountPoint = AuthMethodDefaultPaths.CloudFoundry);

        /// <summary>
        /// Deletes a role.
        /// </summary>
        /// <param name="role">The name of the role</param>
        /// <param name="mountPoint"></param>
        /// <returns></returns>
        Task DeleteRoleAsync(string role, string mountPoint = AuthMethodDefaultPaths.CloudFoundry);
    }
}
