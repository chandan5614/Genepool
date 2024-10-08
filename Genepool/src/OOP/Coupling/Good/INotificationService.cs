using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.OOP.Coupling.Good
{
    public interface INotificationService
    {
        public void SendNotification(string message);
    }
}