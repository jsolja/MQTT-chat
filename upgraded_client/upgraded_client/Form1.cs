using System;
using System.Media;
using System.Text;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
namespace upgraded_client
{
    public partial class Form1 : Form
    {
        MqttClient client;
        byte code;
        ushort msgId_P;
        ushort msgId_S;
        string tema;
        string broker_address;
        string user;
        string password;
        ushort msgId_US;
        int povezano=0;
        delegate void SetTextCallback(string text);
        public Form1()
        {
            InitializeComponent();
            sakrij1();
        }
        
        SoundPlayer simpleSound_in = new SoundPlayer(@"bip_in.wav");
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(textBox1.Text)))
                posalji();
        }

        private void prijavaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            textBox2.Show();
            textBox3.Show();
            textBox4.Show();
            textBox5.Show();
            button2.Show();
        }
        private void sakrij1()
        {
            richTextBox1.Hide();
            button1.Hide();
            novaTemaToolStripMenuItem.Visible = false;
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            button2.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox4.Text));
            else
            {
                broker_address = textBox5.Text;
                tema = textBox4.Text;
                user = textBox2.Text;
                password = textBox3.Text;
                povezano=povezi();
                if (povezano == 1)
                {
                    label1.Hide();
                    label2.Hide();
                    label3.Hide();
                    label4.Hide();
                    textBox2.Hide();
                    textBox3.Hide();
                    textBox4.Hide();
                    textBox5.Hide();
                    button2.Hide();
                    richTextBox1.Show();
                    textBox1.Show();
                    button1.Show();
                    novaTemaToolStripMenuItem.Visible = true;
                    prijavaToolStripMenuItem.Visible = false;
                }
                else
                {

                }
            }
        }
        private void SetText(string text)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                Invoke(d, new object[] { text });
                simpleSound_in.Play();
            }
            else
            {
                richTextBox1.Text += "\n" + text;
               
            }
        }
        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                SetText(System.Text.Encoding.UTF8.GetString(e.Message));
                
            }
            else
            {
                richTextBox1.Text +="\n" + e.Message;
                
            }
        }
        private int povezi()
        { 
            try
            {
                client = new MqttClient(broker_address);
                code = client.Connect(Guid.NewGuid().ToString());
            }
            catch
            {
                return 0;
            }
                msgId_S = client.Subscribe(new string[] {tema},
                                           new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            String timeStamp = GetTimestamp(DateTime.Now);
            richTextBox1.Text = "Povezan! Tema: ";
                richTextBox1.AppendText(tema.ToString());
                client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
                msgId_P = client.Publish(tema,
                Encoding.UTF8.GetBytes("[" + timeStamp + "] " + user + " je povezan."),
                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                true);
            return 1;
         }

        private void novaTemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Hide();
            button1.Hide();
            novaTemaToolStripMenuItem.Visible = false;
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            button2.Hide();
            msgId_US = client.Unsubscribe(new string[] {tema});
            label3.Show();
            textBox4.Show();
            button2.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (povezano == 1){
                String timeStamp = GetTimestamp(DateTime.Now);
                msgId_P = client.Publish(tema,
                Encoding.UTF8.GetBytes("[" + timeStamp + "] " + user + " je otišao."),
                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                true);
                client.Disconnect();
            }
                

            if (System.Windows.Forms.Application.MessageLoop)
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                System.Environment.Exit(1);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar==Keys.Enter) {
                if (!(string.IsNullOrEmpty(textBox1.Text))){
                    posalji();
                    e.Handled = true;
                }
            }
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("HH:mm");
        }

        private void posalji()
        {
            String timeStamp = GetTimestamp(DateTime.Now);
            msgId_P = client.Publish(tema,
            Encoding.UTF8.GetBytes("[" + timeStamp + "] " + user + ": " + textBox1.Text),
            MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
            true);
            textBox1.Clear();
        }
    }
}
