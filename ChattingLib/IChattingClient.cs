using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattingLib
{
    public interface IChattingClient
    {
        void RetrieveMessage(MessageClass message);
    }
}
