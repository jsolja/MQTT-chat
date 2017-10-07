using System;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace upgraded_client
{
    public partial class FrmConnectedToTopic : Form
    {
        String BrokerAdress { get; set; }
        String Topic { get; set; }
        String User { get; set; }
        MqttClient Client { get; set; }
        SoundPlayer Sound { get; set; }
        int SoundOnOff = 1;
        delegate void SetTextCallback(string text);
        ushort msgId_S = 0;
        ushort msgId_P = 0;
        public FrmConnectedToTopic(string broker_address, string topic, string user)
        {
            InitializeComponent();
            BrokerAdress = broker_address;
            Topic = topic;
            User = user;
            Connect();
            Sound = new SoundPlayer(@"bip_in.wav");
            inputSound.BackgroundImage = Image.FromFile(@"../../resources/soundon.png");
        }

        private void Connect()
        {
            byte code;

            try
            {
                Client = new MqttClient(BrokerAdress);
                code = Client.Connect(Guid.NewGuid().ToString());
            }
            catch
            {
                MessageBox.Show("ERROR: Failed to connect!");
                FrmLogin formLogin = new FrmLogin();
                formLogin.ShowDialog();
            }

            msgId_S = Client.Subscribe(new string[] { Topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            Client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            outputChat.Text = "Connected! Topic: ";
            outputChat.AppendText(Topic.ToString());
            String timeStamp = GetTimestamp(DateTime.Now);
            msgId_P = Client.Publish(Topic, Encoding.UTF8.GetBytes("[" + timeStamp + "] " + User + " connected."), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }

        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            if(outputChat.InvokeRequired)
            {
                SetText(Encoding.UTF8.GetString(e.Message));
            }
            else
            {
                outputChat.Text +="\n" + e.Message;
            }
        }

        private void SetText(string text)
        {
            if (this.outputChat.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                Invoke(d, new object[] { text });
                if(SoundOnOff == 1)
                {
                    Sound.Play();
                }
            }
            else
            {
                outputChat.Text += "\n" + text;
               
            } 
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("HH:mm");
        }
        private void Send()
        {
            String timeStamp = GetTimestamp(DateTime.Now);
            msgId_P = Client.Publish(Topic, Encoding.UTF8.GetBytes("[" + timeStamp + "] " + User + ": " + inputChat.Text),
            MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
            inputChat.Clear();
        }
        private void inputSend_Click(object sender, EventArgs e)
        {
            if(inputChat.Text.Trim() != "")
            {
                Send();
            }
        }

        private void Disconnect()
        {
            String timeStamp = GetTimestamp(DateTime.Now);
            msgId_P = Client.Publish(Topic, Encoding.UTF8.GetBytes("[" + timeStamp + "] " + User + " left."), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
            Client.Disconnect();

            this.Hide();
            FrmMain formMain = new FrmMain();
            formMain.ShowDialog();
        }

        private void inputSignout_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void FrmConnectedToTopic_FormClosed(object sender, FormClosedEventArgs e)
        {
            Disconnect();
        }

        private void inputChat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((Keys)e.KeyChar == Keys.Enter)
            {
                if (!(string.IsNullOrEmpty(inputChat.Text)))
                {
                    Send();
                    e.Handled = true;
                }
            }
        }

        private void inputSound_Click(object sender, EventArgs e)
        {
            if (SoundOnOff == 1)
            {
                inputSound.BackgroundImage = Image.FromFile(@"../../resources/soundoff.png");
                SoundOnOff = 0;
            }
            else
            {
                inputSound.BackgroundImage = Image.FromFile(@"../../resources/soundon.png");
                SoundOnOff = 1;
            }
        }
    }
}
