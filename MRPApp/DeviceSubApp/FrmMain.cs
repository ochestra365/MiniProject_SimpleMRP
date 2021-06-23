using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace DeviceSubApp
{
    public partial class FrmMain : Form
    {
        MqttClient client;
        string connectionString;//DB연결 문자열 | MQTT Broker address
        ulong lineCount;
        delegate void UpdateTextCallback(string message);//스레드상에서 윈폼 RichTextbox 텍스트를 출력할 때 필요한 것

        public FrmMain()
        {
            InitializeComponent();
            InitailizeAllData();
        }

        private void InitailizeAllData()
        {
            connectionString = "Data Source="+TxtConnectionString.Text+";Initial Catalog=MRP;User ID=sa;password=mssql_p@ssw0rd!";
            lineCount = 0;
            BtnConnect.Enabled = true;
            BtnDisconnect.Enabled = false;
            IPAddress brokerAddress;
            try
            {
                brokerAddress = IPAddress.Parse(TxtConnectionString.Text);
                client = new MqttClient(brokerAddress);
                //client= new (MqttClient.)brokerAdd
                client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Client_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                RtbSubscr.AppendText($">>>>ERROR!! : {ex.Message}");
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            client.Connect(TxtClientID.Text);//SUBSCR01
            RtbSubscr.AppendText(">>>>> Client Connect\n");
            client.Subscribe(new string[] { TxtSubscriptionTopic.Text },
                new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            RtbSubscr.AppendText(">>>>Subscring to : " + TxtSubscriptionTopic.Text+"\n");

            BtnConnect.Enabled = false;
            BtnDisconnect.Enabled = true;
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            client.Disconnect();
            RtbSubscr.AppendText(">>>>Client disconnected\n");
            BtnConnect.Enabled = true;
            BtnDisconnect.Enabled = false;
        }
    }
}
