
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidySphere.Application.Services
{
    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetTenantId()
        {
            return Convert.ToInt32(_httpContextAccessor.HttpContext?.Items["TenantId"]);
        }


        public int TenantId
        {
            get
            {
                var tenant = _httpContextAccessor.HttpContext?.Items["TenantId"];

                if (tenant == null)
                    throw new Exception("Tenant not found");

                return Convert.ToInt32(tenant);
            }
        }
    }
}
