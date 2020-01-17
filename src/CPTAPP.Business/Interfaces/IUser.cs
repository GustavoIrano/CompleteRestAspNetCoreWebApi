using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CPTAPP.Business.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        string GetUserEmail();
        bool IsAuthenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();
        Guid GetUserId();
    }
}
