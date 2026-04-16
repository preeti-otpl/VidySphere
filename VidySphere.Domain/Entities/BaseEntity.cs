using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidySphere.Domain.Entities;

public abstract class BaseEntity
{
    public long Id { get; set; }

    // 🔥 Multi-tenant support
    public int TenantId { get; set; }
    // Creation
    public DateTime CreatedAt { get; set; }
    public long? CreatedBy { get; set; }

    // Update
    public DateTime? UpdatedAt { get; set; }
    public long? UpdatedBy { get; set; }

    // Soft Delete
    public DateTime? DeletedAt { get; set; }

    // Concurrency (Optimistic Locking)
    public byte[] RowVersion { get; set; }
}
