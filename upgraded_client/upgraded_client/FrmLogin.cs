using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace upgraded_client
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void inputConnect_Click(object sender, EventArgs e)
        {
            if(inputAddress.Text.Trim() == "" || inputUsername.Text.Trim() == "" || inputTopic.Text.Trim() == "")
            {
                MessageBox.Show("ERROR: You must fill all fields!");
            }
            else
            {
                Connect();
            }
        }

        private void Connect()
        {
            string broker_address = inputAddress.Text;
            string topic = inputTopic.Text;
            string user = inputUsername.Text;

            FrmConnectedToTopic formCTT = new FrmConnectedToTopic(broker_address, topic, user);
            this.Hide();
            formCTT.ShowDialog();
        }
        private void inputTopic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((Keys)e.KeyChar == Keys.Enter)
            {
                Connect();
                e.Handled = true;
            }
        }
    }
}
