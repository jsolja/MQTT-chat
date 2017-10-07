using System;
using System.Text;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt.Messages;
namespace upgraded_client
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void novaTemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            richTextBox1.Hide();
            button1.Hide();
            novaTemaToolStripMenuItem.Visible = false;
            label1.Hide();

            label3.Hide();
            label4.Hide();
            textBox1.Hide();
            textBox2.Hide();

            textBox4.Hide();
            textBox5.Hide();
            button2.Hide();
            msgId_US = client.Unsubscribe(new string[] {tema});
            label3.Show();
            textBox4.Show();
            button2.Show();
            */
        }

        private void inputSignin_Click(object sender, EventArgs e)
        {
            FrmLogin formLogin = new FrmLogin();
            this.Hide();
            formLogin.ShowDialog();
        }
    }
}
