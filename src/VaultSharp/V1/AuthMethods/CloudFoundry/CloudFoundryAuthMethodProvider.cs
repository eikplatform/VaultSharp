using System.Net.Http;
using System.Threading.Tasks;
using VaultSharp.Core;
using VaultSharp.V1.AuthMethods.CloudFoundry.Models;
using VaultSharp.V1.Commons;

namespace VaultSharp.V1.AuthMethods.CloudFoundry
{
    internal class CloudFoundryAuthMethodProvider : ICloudFoundryAuthMethod
    {
        private readonly Polymath _polymath;
        private static readonly HttpMethod HttpMethodList = new HttpMethod("LIST");

        public CloudFoundryAuthMethodProvider(Polymath polymath)
        {
            Checker.NotNull(polymath, "polymath");
            _polymath = polymath;
        }

        public async Task CreateRoleAsync(string role, RoleInfo request,
            string mountPoint = AuthMethodDefaultPaths.CloudFoundry)
        {
            Checker.NotNull(mountPoint, "mountPoint");
            Checker.NotNull(role, "role");
            
            await _polymath.MakeVaultApiRequest("/auth/" + mountPoint.Trim('/'),
                "/roles/" + role.Trim('/'), HttpMethod.Post, request);
        }

        public async Task<Secret<RoleInfo>> GetRoleAsync(string role, string mountPoint = AuthMethodDefaultPaths.CloudFoundry)
        {
            Checker.NotNull(mountPoint, "mountPoint");
            Checker.NotNull(role, "role");

            return await _polymath.MakeVaultApiRequest<Secret<RoleInfo>>("/auth/" + mountPoint.Trim('/'),
                "/roles/" + role.Trim('/'), HttpMethod.Get);

        }

        public async Task<Secret<RoleList>> ListRolesAsync(string mountPoint = AuthMethodDefaultPaths.CloudFoundry)
        {
            Checker.NotNull(mountPoint, "mountPoint");

            return await _polymath.MakeVaultApiRequest<Secret<RoleList>>("/auth/" + mountPoint.Trim('/'),
                "/roles/", HttpMethodList);
        }

        public async Task DeleteRoleAsync(string role, string mountPoint = AuthMethodDefaultPaths.CloudFoundry)
        {
            Checker.NotNull(role, "role");
            Checker.NotNull(mountPoint, "mountPoint");
            
            await _polymath.MakeVaultApiRequest("/auth/" + mountPoint.Trim('/'),
                "/roles/" + role.Trim('/'), HttpMethod.Delete);
        }
    }
}