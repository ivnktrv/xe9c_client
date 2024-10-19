using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace xe9c;

public interface Xe9c_baseFuncs
{
    string ConnectionInfo();
    Socket _connectToGateway();
    void RecieveMsg();
    void SendMsg();
}
