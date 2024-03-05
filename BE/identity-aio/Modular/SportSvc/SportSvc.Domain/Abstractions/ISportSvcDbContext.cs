using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Domain.Abstractions
{
    public interface ISportSvcDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
