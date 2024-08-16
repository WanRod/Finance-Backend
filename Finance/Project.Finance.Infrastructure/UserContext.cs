using Microsoft.AspNetCore.Http;
using Project.Finance.Domain.Interfaces;

namespace Project.Finance.Infrastructure;

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public Guid UserId
    {
        get
        {
            var userIdClaim = httpContextAccessor.HttpContext.User.FindFirst("id");
            return Guid.Parse(userIdClaim!.Value);
        }
    }
}
