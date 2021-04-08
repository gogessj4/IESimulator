using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FrontSimulator
{
    public interface ISignalRManager
    {
        Task ConnectHubs();
    }
}
