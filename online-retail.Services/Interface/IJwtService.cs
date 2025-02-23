using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_retail.Repositories.Entities;

namespace online_retail.Services.Interface
{
    public interface IJwtService
    {
        string GenerateJwtToken(User user);
        Guid? ValidateJwtToken(string token);
    }
}
