using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattingLib
{
    public interface IChatting
    {
        void SetToDatabase(string username, string text);

        List<string> GetFromDatabase();
    }
}
