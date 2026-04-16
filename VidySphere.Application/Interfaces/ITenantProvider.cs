using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidySphere.Application.Interfaces
{
    public interface ITenantProvider
    {
        int GetTenantId();
    }
}
