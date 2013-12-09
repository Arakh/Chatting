using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattingLib
{
    public class MessageClass
    {
        private int _id;
        private string _username;
        string date;
        private string message;

        public int Id
        {
          get { return _id; }
          set { _id = value; }
        }
        
        public string Username
        {
          get { return _username; }
          set { _username = value; }
        }
                

        public string Date
        {
          get { return date; }
          set { date = value; }
        }


        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }
}
