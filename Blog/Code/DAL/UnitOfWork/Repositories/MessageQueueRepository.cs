using Synczon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synczon.DAL {
    public class MessageQueueRepository : Repository<MessageQueue>, IMessageQueueRepository {

        public MessageQueueRepository(SynczonDbContext aContext) : base(aContext) {
            // void
        }

        public MessageQueue GetNextMessage(int aTenantId) {
            var nextMessage = mEntity.Take(1)
                                .Where(e => e.Task.TenantId == aTenantId &&
                                            e.Status == QueueStatus.Pending)
                                .OrderByDescending(x => x.QueuedOn)
                                .First();
                                    
            return nextMessage;
        }

    }
}
