using Synczon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synczon.DAL {

public class TenantRepository : Repository<Tenant>, ITenantRepository {

    public TenantRepository(SynczonDbContext aContext) : base(aContext) {
        // void
    }

    public Tenant GetTenant(string aSubscriptionId) {
        var tenant = mEntity.FirstOrDefault(e => e.StripeSubscriptionId == aSubscriptionId);
        return tenant;
    }
             
}

}
