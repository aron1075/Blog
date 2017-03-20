using Synczon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synczon.DAL {

public class jobRepository : Repository<Job>, IJobRepository {

    public jobRepository(SynczonDbContext aContext) : base(aContext) {
        // void
    }

    public Job GetJob(string aJobName) {
        var job = mEntity.FirstOrDefault(e => e.Name == aJobName);
        return job;
    }

}

}
