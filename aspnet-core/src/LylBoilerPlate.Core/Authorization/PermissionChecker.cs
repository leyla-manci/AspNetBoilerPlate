using Abp.Authorization;
using LylBoilerPlate.Authorization.Roles;
using LylBoilerPlate.Authorization.Users;

namespace LylBoilerPlate.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
