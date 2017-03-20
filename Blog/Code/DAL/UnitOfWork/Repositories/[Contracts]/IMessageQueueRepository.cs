﻿using Synczon.DAL.Contracts;
using Synczon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synczon.DAL {

public interface IMessageQueueRepository : IRepository<MessageQueue> {

    MessageQueue GetNextMessage(int aTenantId);

}

}
