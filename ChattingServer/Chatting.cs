using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChattingLibrary;
using ChattingClient;

namespace ChattingServer
{
    public class Chatting : MarshalByRefObject, IChat
    {
        public void SetToDatabase(string username, string text)
        {
            using (chatting_rpcEntities1 chattingData = new chatting_rpcEntities1())
            {
                try
                {
                    chat newChat = new chat();
                    newChat.username = username;
                    newChat.text = text;
                    chattingData.chats.Add(newChat);
                    chattingData.SaveChanges();
                }

                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
        }





        public string[] GetFromDatabase()
        {
            string[] listMessage = new string[4];
            using (chatting_rpcEntities1 chattingData = new chatting_rpcEntities1())
            {
                try
                {
                    var query = (from tabelchat in chattingData.chats
                                 orderby tabelchat.id descending
                                 select tabelchat).Take(1);
                    foreach (var item in query)
                    {
                        listMessage[0] = item.id.ToString();
                        listMessage[1]=item.username;
                        listMessage[2]=item.text;
                        listMessage[3]=item.date.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return listMessage;
            }
        }
    }

}
