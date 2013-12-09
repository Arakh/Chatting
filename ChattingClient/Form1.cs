using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ChattingLibrary;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Timers;

namespace ChattingClient
{
    public partial class Form1 : Form
    {
        private  IChat _remoteServer=null;
        private Thread _read;
        private Thread _write;
        private string [] _listMessage;
        private EnkripsiDekripsi _acak = new EnkripsiDekripsi();
        System.Timers.Timer timer;


        public Form1()
        {
            InitializeComponent();
            //_read = new Thread(new ThreadStart(RetrieveMessage));
            //_read.Start();
            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(TimerElepsed);
            timer.Enabled = true;

            _listMessage = new string [4];

            ChannelServices.RegisterChannel(new TcpChannel(), false);
            string server = "localhost";
            string port = "1234";
            string uri = "RemoteChatting";
            string url = "tcp://" + server + ":" + port + "/" + uri;
            _remoteServer = (IChat)Activator.GetObject(typeof(IChat), url);
        }

        private void TimerElepsed(object sender, ElapsedEventArgs e)
        {
            int interval = Convert.ToInt32(DateTime.Now.Millisecond);
            if (interval % 2 == 0)
                RetrieveMessage();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Width = SystemInformation.VirtualScreen.Width  - 25;
            listBox1.Height = SystemInformation.VirtualScreen.Height - ( tbUsername.Height + tbMessage.Height + 100); 
            
            tbMessage.Width = Convert.ToInt32(SystemInformation.VirtualScreen.Width * 0.80);
            tbMessage.Location  = new Point(12, listBox1.Height+25 + tbUsername.Height);

            btnSend.Width = Convert.ToInt32(SystemInformation.VirtualScreen.Width * 0.18);
            btnSend.Location = new Point(18 + tbMessage.Width, listBox1.Height+25+tbUsername.Height);
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!tbMessage.Text.Equals(""))
            {
                _write = new Thread(new ThreadStart(SendMessege));
                _write.Start();
                this.SendMessege();
            }
        }

        private void SendMessege()
        {
            if (tbUsername.Text.Equals(""))
                tbUsername.Text = "anonymous";

            _remoteServer.SetToDatabase(tbUsername.Text, _acak.Enkripsi(tbMessage.Text));
            tbMessage.Text = "";
            _write.Abort();
        }


        public void RetrieveMessage()
        {
                try
                {
                    string [] temp = _remoteServer.GetFromDatabase();
            
                    if (temp[0] != _listMessage[0])
                    {
                        _listMessage = temp;
                        this.Invoke((MethodInvoker)delegate{
                        listBox1.Items.Add(_listMessage[1]+" : "+_acak.Dekripsi(_listMessage[2]));
                        listBox1.Items.Add(DateTime.Now);
                        listBox1.Items.Add("");
                        });
                    }
                }
                catch 
                {
                }
            
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            _read.Abort();
        }
    }
}
