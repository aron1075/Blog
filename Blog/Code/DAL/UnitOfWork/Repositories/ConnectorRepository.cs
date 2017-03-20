using Synczon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synczon.DAL {

public class ConnectorRepository : Repository<Connector>, IConnectorRepository {

    public ConnectorRepository(SynczonDbContext aContext) : base(aContext) {
        // void
    }

    public bool IsMessageAuthenticated(Guid aId) {
        var idExists = mEntity.Any(e => e.Id == aId);
        return idExists;
    }

}

}
