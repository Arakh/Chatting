using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattingLibrary
{
    public interface IChat
    {
        void SetToDatabase(string username, string text);

        string [] GetFromDatabase();
    }
}
